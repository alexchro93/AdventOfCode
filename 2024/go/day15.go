package main

import (
	"fmt"

	"github.com/alexchro93/2024/go/utils"
)

func ParseDay15Input(two bool) ([][]rune, []rune, error) {
	lines, err := utils.ReadAllLines("input/day15.txt")
	if err != nil {
		return nil, nil, err
	}

	grid := make([][]rune, 0)
	moves := make([]rune, 0)
	parseGrid := true
	for _, line := range lines {
		if line == "" {
			parseGrid = !parseGrid
			continue
		}
		if parseGrid {
			if two {
				row := make([]rune, 0)
				for _, c := range line {
					if c == '.' {
						row = append(row, '.', '.')
					} else if c == '#' {
						row = append(row, '#', '#')
					} else if c == '@' {
						row = append(row, '@', '.')
					} else if c == 'O' {
						row = append(row, '[', ']')
					}
				}
				grid = append(grid, row)
			} else {
				grid = append(grid, []rune(line))
			}
		} else {
			moves = append(moves, []rune(line)...)
		}
	}
	return grid, moves, nil
}

func find(grid [][]rune, target rune) (utils.Point, error) {
	for y, row := range grid {
		for x, cell := range row {
			if cell == target {
				return utils.Point{X: x, Y: y}, nil
			}
		}
	}
	return utils.Point{}, fmt.Errorf("target not found")
}

func movePoint(p utils.Point, dir rune) (utils.Point, error) {
	switch dir {
	case '^':
		return utils.Point{X: p.X, Y: p.Y - 1}, nil
	case 'v':
		return utils.Point{X: p.X, Y: p.Y + 1}, nil
	case '<':
		return utils.Point{X: p.X - 1, Y: p.Y}, nil
	case '>':
		return utils.Point{X: p.X + 1, Y: p.Y}, nil
	}
	return utils.Point{}, fmt.Errorf("invalid direction")
}

func canMove(grid [][]rune, maxX, maxY int, dir rune, p utils.Point) bool {
	newPoint, error := movePoint(p, dir)
	if error != nil {
		return false
	}

	if newPoint.X < 0 || newPoint.X >= maxX || newPoint.Y < 0 || newPoint.Y >= maxY {
		return false
	}

	val := grid[newPoint.Y][newPoint.X]
	if val == '#' {
		return false
	}
	if val == 'O' {
		return canMove(grid, maxX, maxY, dir, newPoint)
	}
	return true
}

func canMoveTwo(grid [][]rune, maxX, maxY int, dir rune, p utils.Point) bool {
	newPoint, error := movePoint(p, dir)
	if error != nil {
		return false
	}

	if newPoint.X < 0 || newPoint.X >= maxX || newPoint.Y < 0 || newPoint.Y >= maxY {
		return false
	}

	val := grid[newPoint.Y][newPoint.X]
	if val == '#' {
		return false
	}
	if (val == '[' || val == ']') && (dir == '>' || dir == '<') {
		return canMoveTwo(grid, maxX, maxY, dir, newPoint)
	}
	if (val == '[' || val == ']') && (dir == '^' || dir == 'v') {
		if val == '[' {
			return canMoveTwo(grid, maxX, maxY, dir, newPoint) && canMoveTwo(grid, maxX, maxY, dir, utils.Point{X: newPoint.X + 1, Y: newPoint.Y})
		}
		if val == ']' {
			return canMoveTwo(grid, maxX, maxY, dir, newPoint) && canMoveTwo(grid, maxX, maxY, dir, utils.Point{X: newPoint.X - 1, Y: newPoint.Y})
		}
	}
	return true
}

func moveThings(grid [][]rune, dir rune, p utils.Point) utils.Point {
	newPoint, _ := movePoint(p, dir)
	current := grid[p.Y][p.X]
	next := grid[newPoint.Y][newPoint.X]
	if next == 'O' {
		moveThings(grid, dir, newPoint)
	}
	grid[newPoint.Y][newPoint.X] = current
	grid[p.Y][p.X] = '.'
	return newPoint
}

func moveThingsTwo(grid [][]rune, dir rune, p utils.Point) utils.Point {
	newPoint, _ := movePoint(p, dir)
	current := grid[p.Y][p.X]
	next := grid[newPoint.Y][newPoint.X]
	if (next == '[' || next == ']') && (dir == '>' || dir == '<') {
		moveThingsTwo(grid, dir, newPoint)
	}
	if (next == '[' || next == ']') && (dir == '^' || dir == 'v') {
		if next == '[' {
			moveThingsTwo(grid, dir, newPoint)
			moveThingsTwo(grid, dir, utils.Point{X: newPoint.X + 1, Y: newPoint.Y})
		}
		if next == ']' {
			moveThingsTwo(grid, dir, newPoint)
			moveThingsTwo(grid, dir, utils.Point{X: newPoint.X - 1, Y: newPoint.Y})
		}
	}
	grid[newPoint.Y][newPoint.X] = current
	grid[p.Y][p.X] = '.'
	return newPoint
}

func Day15() {
	grid, moves, err := ParseDay15Input(false)
	if err != nil {
		return
	}

	maxY := len(grid)
	maxX := len(grid[0])

	// Part One
	start, err := find(grid, '@')
	if err != nil {
		return
	}
	for _, move := range moves {
		if canMove(grid, maxX, maxY, move, start) {
			start = moveThings(grid, move, start)
		}
	}
	sum1 := 0
	for y := range grid {
		for x := range grid[y] {
			if grid[y][x] == 'O' {
				sum1 += 100*y + x
			}
		}
	}

	fmt.Printf("Day 15 Part 1: %v\n", sum1)

	// Part Two
	grid, moves, err = ParseDay15Input(true)
	if err != nil {
		return
	}

	maxY = len(grid)
	maxX = len(grid[0])

	start, err = find(grid, '@')
	if err != nil {
		return
	}
	for _, move := range moves {
		if canMoveTwo(grid, maxX, maxY, move, start) {
			start = moveThingsTwo(grid, move, start)
		}
	}
	sum2 := 0
	for y := range grid {
		for x := range grid[y] {
			if grid[y][x] == '[' {
				sum2 += 100*y + x
			}
		}
	}

	fmt.Printf("Day 15 Part 2: %v\n", sum2)
}
