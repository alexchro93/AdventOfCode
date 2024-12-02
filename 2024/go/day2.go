package main

import (
	"fmt"
	"slices"
	"strconv"
	"strings"

	"github.com/alexchro93/2024/go/utils"
)

func isValid(items []int) bool {
	for i := 1; i < len(items); i++ {
		diff := items[i] - items[i-1]
		if diff < -3 || diff > 3 || diff == 0 {
			return false
		}

		if i == 1 {
			continue
		}

		if (items[i] > items[i-1] && items[i-1] < items[i-2]) || (items[i] < items[i-1] && items[i-1] > items[i-2]) {
			return false
		}
	}

	return true
}

func Day2() {
	lines, err := utils.ReadAllLines("input/day2.txt")
	if err != nil {
		fmt.Println("Error reading file day2.txt")
		return
	}

	input := make([][]int, 0)
	for _, line := range lines {
		items := make([]int, 0)
		for _, item := range strings.Split(line, " ") {
			val, _ := strconv.Atoi(item)
			items = append(items, val)
		}
		input = append(input, items)
	}

	// Part One
	sum := 0
	for _, items := range input {
		if isValid(items) {
			sum++
		}
	}

	fmt.Printf("Day 2 Part 1: %v\n", sum)

	// Part Two
	sum = 0
	for _, items := range input {
		if isValid(items) {
			sum++
		} else {
			for i := 0; i < len(items); i++ {
				copyItems := make([]int, len(items))
				copy(copyItems, items)

				copyItems = slices.Delete(copyItems, i, i+1)
				if isValid(copyItems) {
					sum++
					break
				}
			}
		}
	}

	fmt.Printf("Day 2 Part 2: %v\n", sum)
}
