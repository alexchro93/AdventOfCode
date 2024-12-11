package main

import (
	"fmt"

	"github.com/alexchro93/2024/go/utils"
)

func ParseDay10Input() ([]utils.Point, [][]rune, error) {
	lines, err := utils.ReadAllLines("input/day10.txt")
	if err != nil {
		return nil, nil, err
	}

	points := make([]utils.Point, 0)
	grid := make([][]rune, 0)

	for i, line := range lines {
		grid = append(grid, []rune(line))
		for j, r := range line {
			if r == '0' {
				points = append(points, utils.Point{X: j, Y: i})
			}
		}
	}

	return points, grid, nil
}

func CheckPoint(current, next utils.Point, maxX, maxY int, grid [][]rune) bool {
	if next.X < 0 || next.X >= maxX || next.Y < 0 || next.Y >= maxY {
		return false
	}
	c := int(grid[current.Y][current.X] - '0')
	n := int(grid[next.Y][next.X] - '0')
	return (n - c) == 1
}

func FindPaths(current utils.Point, maxX, maxY int, grid [][]rune) map[utils.Point]int {
	paths := make(map[utils.Point]int, 0)

	if current.X < 0 || current.X >= maxX || current.Y < 0 || current.Y >= maxY {
		return paths
	}

	if grid[current.Y][current.X] == '9' {
		paths[current] = 1
		return paths
	}

	down := utils.Point{X: current.X, Y: current.Y - 1}
	if CheckPoint(current, down, maxX, maxY, grid) {
		m := FindPaths(down, maxX, maxY, grid)
		utils.MergeMaps(paths, m)
	}

	up := utils.Point{X: current.X, Y: current.Y + 1}
	if CheckPoint(current, up, maxX, maxY, grid) {
		m := FindPaths(up, maxX, maxY, grid)
		utils.MergeMaps(paths, m)
	}

	left := utils.Point{X: current.X - 1, Y: current.Y}
	if CheckPoint(current, left, maxX, maxY, grid) {
		m := FindPaths(left, maxX, maxY, grid)
		utils.MergeMaps(paths, m)
	}

	right := utils.Point{X: current.X + 1, Y: current.Y}
	if CheckPoint(current, right, maxX, maxY, grid) {
		m := FindPaths(right, maxX, maxY, grid)
		utils.MergeMaps(paths, m)
	}

	return paths
}

func Day10() {
	points, grid, err := ParseDay10Input()
	if err != nil {
		return
	}

	maxX := len(grid[0])
	maxY := len(grid)

	// Part One
	sum1 := 0
	for _, point := range points {
		m := FindPaths(point, maxX, maxY, grid)
		sum1 += len(m)
	}

	fmt.Printf("Day 10 Part 1: %v\n", sum1)

	// Part Two
	sum2 := 0
	for _, point := range points {
		m := FindPaths(point, maxX, maxY, grid)
		for _, v := range m {
			sum2 += v
		}
	}

	fmt.Printf("Day 10 Part 2: %v\n", sum2)
}
