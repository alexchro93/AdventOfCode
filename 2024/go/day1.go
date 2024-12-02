package main

import (
	"fmt"
	"sort"
	"strconv"
	"strings"

	"github.com/alexchro93/2024/go/utils"
)

func Day1() {
	// Part One
	lines, err := utils.ReadAllLines("input/day1.txt")
	if err != nil {
		fmt.Println("Error reading file day1.txt")
		return
	}

	left := make([]int, 500)
	right := make([]int, 500)

	for _, line := range lines {
		parts := strings.Split(line, "   ")
		if len(parts) != 2 {
			fmt.Println("Invalid line format:", line)
			continue
		}

		leftVal, _ := strconv.Atoi(parts[0])
		rightVal, _ := strconv.Atoi(parts[1])

		left = append(left, leftVal)
		right = append(right, rightVal)
	}

	sort.Ints(left)
	sort.Ints(right)

	diff := 0
	for i := 0; i < len(left); i++ {
		l := left[i]
		r := right[i]

		distance := l - r
		if distance < 0 {
			distance = -distance
		}

		diff += distance
	}

	fmt.Printf("Day 1 Part 1: %v\n", diff)

	// Part Two
	sim := 0
	for _, i := range left {
		count := 0
		for j := 0; j < len(right); j++ {
			if right[j] > i {
				break
			}
			if i == right[j] {
				count++
			}
		}
		sim += i * count
	}

	fmt.Printf("Day 1 Part 2: %v\n", sim)
}
