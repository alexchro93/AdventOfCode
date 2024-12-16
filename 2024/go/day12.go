package main

import (
	"fmt"

	"github.com/alexchro93/2024/go/utils"
)

func ParseDay12Input() ([][]rune, error) {
	lines, err := utils.ReadAllLines("input/day12.txt")
	if err != nil {
		return nil, err
	}
	input := make([][]rune, 0)
	for _, line := range lines {
		input = append(input, []rune(line))
	}
	return input, nil
}

func GetPerimeter(point utils.Point, target rune, maxX, maxY int, input *[][]rune) int {
	if point.X < 0 || point.X >= maxX || point.Y < 0 || point.Y >= maxY {
		return 1
	}

	if (*input)[point.Y][point.X] != target {
		return 1
	}

	return 0
}

func GetPerimeterScore(point utils.Point, maxX, maxY int, input *[][]rune) int {
	up := utils.Point{X: point.X, Y: point.Y - 1}
	down := utils.Point{X: point.X, Y: point.Y + 1}
	left := utils.Point{X: point.X - 1, Y: point.Y}
	right := utils.Point{X: point.X + 1, Y: point.Y}

	current := (*input)[point.Y][point.X]
	score := 0

	score += GetPerimeter(up, current, maxX, maxY, input)
	score += GetPerimeter(down, current, maxX, maxY, input)
	score += GetPerimeter(left, current, maxX, maxY, input)
	score += GetPerimeter(right, current, maxX, maxY, input)

	return score
}

func IsTarget(point utils.Point, target rune, maxX, maxY int, input *[][]rune) bool {
	if point.X < 0 || point.X >= maxX || point.Y < 0 || point.Y >= maxY {
		return false
	}

	if (*input)[point.Y][point.X] != target {
		return false
	}

	return true
}

func IsCorner(diag, x, y utils.Point, target rune, maxX, maxY int, input *[][]rune) bool {
	if IsTarget(x, target, maxX, maxY, input) && IsTarget(y, target, maxX, maxY, input) && !IsTarget(diag, target, maxX, maxY, input) {
		return true
	}

	if !IsTarget(x, target, maxX, maxY, input) && !IsTarget(y, target, maxX, maxY, input) {
		return true
	}

	return false
}

func GetCornerScore(point utils.Point, maxX, maxY int, input *[][]rune) int {
	up := utils.Point{X: point.X, Y: point.Y - 1}
	down := utils.Point{X: point.X, Y: point.Y + 1}
	left := utils.Point{X: point.X - 1, Y: point.Y}
	right := utils.Point{X: point.X + 1, Y: point.Y}

	upLeft := utils.Point{X: point.X - 1, Y: point.Y - 1}
	upRight := utils.Point{X: point.X + 1, Y: point.Y - 1}
	downLeft := utils.Point{X: point.X - 1, Y: point.Y + 1}
	downRight := utils.Point{X: point.X + 1, Y: point.Y + 1}

	sum := 0

	if IsCorner(upLeft, up, left, (*input)[point.Y][point.X], maxX, maxY, input) {
		sum++
	}

	if IsCorner(upRight, up, right, (*input)[point.Y][point.X], maxX, maxY, input) {
		sum++
	}

	if IsCorner(downLeft, down, left, (*input)[point.Y][point.X], maxX, maxY, input) {
		sum++
	}

	if IsCorner(downRight, down, right, (*input)[point.Y][point.X], maxX, maxY, input) {
		sum++
	}

	return sum
}

func ProcessPoint(point utils.Point, target rune, maxX, maxY int, input *[][]rune, process *utils.Queue[utils.Point], seen *map[utils.Point]bool, region *[]utils.Point) {
	if point.X < 0 || point.X >= maxX || point.Y < 0 || point.Y >= maxY {
		return
	}

	if ok := (*seen)[point]; ok {
		return
	}

	if (*input)[point.Y][point.X] != target {
		process.Push(point)
		return
	}

	ProcessRegion(point, target, maxX, maxY, input, process, seen, region)
}

func ProcessRegion(start utils.Point, target rune, maxX, maxY int, input *[][]rune, process *utils.Queue[utils.Point], seen *map[utils.Point]bool, region *[]utils.Point) {
	(*seen)[start] = true
	*region = append(*region, start)

	up := utils.Point{X: start.X, Y: start.Y - 1}
	down := utils.Point{X: start.X, Y: start.Y + 1}
	left := utils.Point{X: start.X - 1, Y: start.Y}
	right := utils.Point{X: start.X + 1, Y: start.Y}

	ProcessPoint(up, target, maxX, maxY, input, process, seen, region)
	ProcessPoint(down, target, maxX, maxY, input, process, seen, region)
	ProcessPoint(left, target, maxX, maxY, input, process, seen, region)
	ProcessPoint(right, target, maxX, maxY, input, process, seen, region)
}

func Day12() {
	input, err := ParseDay12Input()
	if err != nil {
		return
	}

	maxY := len(input)
	maxX := len(input[0])

	// Parts One and Two
	process := utils.NewQueue(utils.Point{X: 0, Y: 0})
	seen := make(map[utils.Point]bool, 0)
	sum1 := 0
	sum2 := 0

	for !process.Empty() {
		point := process.Pop()
		if ok := seen[point]; ok {
			continue
		}

		region := make([]utils.Point, 0)
		ProcessRegion(point, input[point.Y][point.X], maxX, maxY, &input, process, &seen, &region)

		// Part One
		area1 := len(region)
		perimeter1 := 0
		for _, point := range region {
			perimeter1 += GetPerimeterScore(point, maxX, maxY, &input)
		}
		sum1 += area1 * perimeter1

		// Part Two
		area2 := len(region)
		perimeter2 := 0
		for _, point := range region {
			perimeter2 += GetCornerScore(point, maxX, maxY, &input)
		}
		sum2 += area2 * perimeter2
	}

	fmt.Printf("Day 12 Part 1: %v\n", sum1)
	fmt.Printf("Day 12 Part 2: %v\n", sum2)
}
