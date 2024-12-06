package main

import (
	"errors"
	"fmt"

	"github.com/alexchro93/2024/go/utils"
)

type Direction int

const (
	Up Direction = iota
	Down
	Left
	Right
)

type VisitInfo struct {
	Previous map[Direction]int
}

type Location struct {
	x, y int
}

func ParseDay6Input() ([][]rune, error) {
	lines, err := utils.ReadAllLines("input/day6.txt")
	if err != nil {
		return nil, err
	}

	data := make([][]rune, len(lines))

	for i, line := range lines {
		data[i] = []rune(line)
	}

	return data, nil
}

func GetNextLocation(loc Location, maxX, maxY int, dir Direction, input [][]rune) (Location, error) {
	switch dir {
	case Up:
		loc.y--
	case Down:
		loc.y++
	case Left:
		loc.x--
	case Right:
		loc.x++
	}

	if loc.x < 0 || loc.x >= maxX || loc.y < 0 || loc.y >= maxY {
		return loc, errors.New("out of bounds")
	}

	return loc, nil
}

func GetNextDirection(dir Direction) Direction {
	switch dir {
	case Up:
		return Right
	case Right:
		return Down
	case Down:
		return Left
	case Left:
		return Up
	}

	return Up
}

func FindPath(startLoc Location, maxX, maxY int, input [][]rune) (*map[Location]VisitInfo, error) {
	visited := make(map[Location]VisitInfo)
	dir := Up
	loc := startLoc

	for loc.x >= 0 && loc.x < maxX && loc.y >= 0 && loc.y < maxY {
		if last, ok := visited[loc]; ok {
			last.Previous[dir]++
			if last.Previous[dir] >= 2 {
				return nil, errors.New("stuck in a loop")
			}
		} else {
			info := make(map[Direction]int)
			info[dir]++
			visited[loc] = VisitInfo{info}
		}
		nextLoc, err := GetNextLocation(loc, maxX, maxY, dir, input)
		if err == nil && input[nextLoc.y][nextLoc.x] == '#' {
			dir = GetNextDirection(dir)
		} else {
			loc = nextLoc
		}
	}

	return &visited, nil
}

func Day6() {
	input, err := ParseDay6Input()
	if err != nil {
		return
	}

	// Part One
	maxY := len(input)
	maxX := len(input[0])

	startLoc := Location{}
	for i, row := range input {
		for j, cell := range row {
			if cell == '^' {
				startLoc = Location{j, i}
			}
		}
	}

	visited, _ := FindPath(startLoc, maxX, maxY, input)

	fmt.Printf("Day 6 Part 1: %v\n", len(*visited))

	// Part Two (brute force)
	numCycles := 0
	for loc := range *visited {
		if loc == startLoc {
			continue
		}
		input[loc.y][loc.x] = '#'
		if _, err := FindPath(startLoc, maxX, maxY, input); err != nil {
			numCycles++
		}
		input[loc.y][loc.x] = '.'
	}

	fmt.Printf("Day 6 Part 2: %v\n", numCycles)
}
