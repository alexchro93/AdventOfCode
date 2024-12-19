package main

import (
	"fmt"
	"regexp"
	"slices"
	"strconv"

	"github.com/alexchro93/2024/go/utils"
)

/*
	The day 14 solution's output is best directed to a file: `go run . 14 > tree.txt`
*/

type robot struct {
	sx, sy, vx, vy int
}

type quad int

const (
	empty quad = iota
	one
	two
	three
	four
)

func ParseDay14Input() ([]robot, error) {
	lines, err := utils.ReadAllLines("input/day14.txt")
	if err != nil {
		return nil, err
	}

	input := make([]robot, 0)
	r := regexp.MustCompile(`p=(-?\d+),(-?\d+) v=(-?\d+),(-?\d+)`)
	for _, line := range lines {
		if match := r.FindStringSubmatch(line); match != nil {
			sx, err := strconv.Atoi(match[1])
			if err != nil {
				return nil, err
			}
			sy, err := strconv.Atoi(match[2])
			if err != nil {
				return nil, err
			}
			vx, err := strconv.Atoi(match[3])
			if err != nil {
				return nil, err
			}
			vy, err := strconv.Atoi(match[4])
			if err != nil {
				return nil, err
			}
			input = append(input, robot{sx, sy, vx, vy})
		}
	}

	return input, nil
}

func move(r *robot, maxX, maxY int) {
	r.sx += r.vx
	for r.sx < 0 {
		r.sx = maxX - (0 - r.sx)
	}
	for r.sx >= maxX {
		r.sx = r.sx - maxX
	}

	r.sy += r.vy
	for r.sy < 0 {
		r.sy = maxY - (0 - r.sy)
	}
	for r.sy >= maxY {
		r.sy = r.sy - maxY
	}
}

func findQuad(r *robot, midX, midY int) quad {
	if r.sx < midX && r.sy < midY {
		return one
	}
	if r.sx < midX && r.sy > midY {
		return two
	}
	if r.sx > midX && r.sy < midY {
		return three
	}
	if r.sx > midX && r.sy > midY {
		return four
	}
	return empty
}

func neighborCount(r *robot, xMax, yMax int, grid *[][]rune) int {
	up := utils.Point{X: r.sx, Y: r.sy - 1}
	down := utils.Point{X: r.sx, Y: r.sy + 1}
	left := utils.Point{X: r.sx - 1, Y: r.sy}
	right := utils.Point{X: r.sx + 1, Y: r.sy}
	upLeft := utils.Point{X: r.sx - 1, Y: r.sy - 1}
	upRight := utils.Point{X: r.sx + 1, Y: r.sy - 1}
	downLeft := utils.Point{X: r.sx - 1, Y: r.sy + 1}
	downRight := utils.Point{X: r.sx + 1, Y: r.sy + 1}

	count := 0
	if up.Y >= 0 && (*grid)[up.Y][up.X] == 'X' {
		count++
	}
	if down.Y < yMax && (*grid)[down.Y][down.X] == 'X' {
		count++
	}
	if left.X >= 0 && (*grid)[left.Y][left.X] == 'X' {
		count++
	}
	if right.X < xMax && (*grid)[right.Y][right.X] == 'X' {
		count++
	}
	if upLeft.X >= 0 && upLeft.Y >= 0 && (*grid)[upLeft.Y][upLeft.X] == 'X' {
		count++
	}
	if upRight.X < xMax && upRight.Y >= 0 && (*grid)[upRight.Y][upRight.X] == 'X' {
		count++
	}
	if downLeft.X >= 0 && downLeft.Y < yMax && (*grid)[downLeft.Y][downLeft.X] == 'X' {
		count++
	}
	if downRight.X < xMax && downRight.Y < yMax && (*grid)[downRight.Y][downRight.X] == 'X' {
		count++
	}

	return count
}

func print(robots *[]robot, xMax, yMax, second int) {
	grid := make([][]rune, yMax)
	for i := range grid {
		grid[i] = slices.Repeat([]rune{'.'}, xMax)
	}

	for j := range *robots {
		grid[(*robots)[j].sy][(*robots)[j].sx] = 'X'
	}

	var sum float64 = 0
	for j := range *robots {
		count := neighborCount(&(*robots)[j], xMax, yMax, &grid)
		if count >= 2 {
			sum++
		}
	}

	if sum/float64(len(*robots)) > 0.5 {
		fmt.Println("Second:", second)
		for j := 0; j < yMax; j++ {
			for i := 0; i < xMax; i++ {
				fmt.Printf("%c", grid[j][i])
			}
			fmt.Print("\n")
		}
		fmt.Print("\n")
	}
}

func Day14() {
	input, err := ParseDay14Input()
	if err != nil {
		return
	}

	xMax := 101
	yMax := 103

	// Part One
	for i := 1; i <= 100; i++ {
		for j := range input {
			move(&input[j], xMax, yMax)
			print(&input, xMax, yMax, i)
		}
	}

	quads := make(map[quad]int)
	for j := range input {
		q := findQuad(&input[j], xMax/2, yMax/2)
		quads[q]++
	}

	sum1 := 1
	for k, v := range quads {
		if k != empty {
			sum1 *= v
		}
	}

	fmt.Printf("Day 14 Part 1: %v\n", sum1)

	// Part Two (visual inspection)
	input, _ = ParseDay14Input()

	for i := 1; i <= 10403; i++ {
		for j := range input {
			move(&input[j], xMax, yMax)
		}
		print(&input, xMax, yMax, i)
	}
}
