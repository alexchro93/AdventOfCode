package main

import (
	"fmt"

	"github.com/alexchro93/2024/go/utils"
)

func findSingle(x, y, xDelta, yDelta, xBound, yBound int, data [][]rune, target []rune) bool {
	for i := 0; i < len(target); i++ {
		if x < 0 || x >= xBound || y < 0 || y >= yBound || data[y][x] != target[i] {
			return false
		}
		x += xDelta
		y += yDelta
	}
	return true
}

func findAll(x, y, xBound, yBound int, data [][]rune, target []rune) int {
	count := 0
	if findSingle(x, y, 1, 0, xBound, yBound, data, target) {
		count++
	}
	if findSingle(x, y, -1, 0, xBound, yBound, data, target) {
		count++
	}
	if findSingle(x, y, 0, 1, xBound, yBound, data, target) {
		count++
	}
	if findSingle(x, y, 0, -1, xBound, yBound, data, target) {
		count++
	}
	if findSingle(x, y, -1, 1, xBound, yBound, data, target) {
		count++
	}
	if findSingle(x, y, 1, 1, xBound, yBound, data, target) {
		count++
	}
	if findSingle(x, y, 1, -1, xBound, yBound, data, target) {
		count++
	}
	if findSingle(x, y, -1, -1, xBound, yBound, data, target) {
		count++
	}
	return count
}

func isMatch(x, y, xBound, yBound int, data [][]rune, target rune) bool {
	return x >= 0 && x < xBound && y >= 0 && y < yBound && data[y][x] == target
}

func findX(x, y, xBound, yBound int, data [][]rune) bool {
	found := 0
	if (isMatch(x-1, y+1, xBound, yBound, data, 'M') && isMatch(x+1, y-1, xBound, yBound, data, 'S')) ||
		(isMatch(x-1, y+1, xBound, yBound, data, 'S') && isMatch(x+1, y-1, xBound, yBound, data, 'M')) {
		found++
	}
	if (isMatch(x+1, y+1, xBound, yBound, data, 'M') && isMatch(x-1, y-1, xBound, yBound, data, 'S')) ||
		(isMatch(x+1, y+1, xBound, yBound, data, 'S') && isMatch(x-1, y-1, xBound, yBound, data, 'M')) {
		found++
	}
	return found == 2
}

func Day4() {
	lines, err := utils.ReadAllLines("input/day4.txt")
	if err != nil {
		fmt.Println("Error reading file day4.txt")
		return
	}

	data := make([][]rune, len(lines))
	for i, line := range lines {
		data[i] = []rune(line)
	}

	xBound := len(data[0])
	yBound := len(data)

	// Part One
	target := []rune("XMAS")
	total1 := 0
	for y := 0; y < yBound; y++ {
		for x := 0; x < xBound; x++ {
			total1 += findAll(x, y, xBound, yBound, data, target)
		}
	}

	fmt.Printf("Day 4 Part 1: %v\n", total1)

	// Part Two
	total2 := 0
	for y := 0; y < yBound; y++ {
		for x := 0; x < xBound; x++ {
			if data[y][x] == 'A' && findX(x, y, xBound, yBound, data) {
				total2++
			}
		}
	}

	fmt.Printf("Day 4 Part 2: %v\n", total2)
}
