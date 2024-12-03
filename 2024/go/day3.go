package main

import (
	"fmt"
	"regexp"
	"strconv"

	"github.com/alexchro93/2024/go/utils"
)

func Day3() {
	lines, err := utils.ReadAllLines("input/day3.txt")
	if err != nil {
		fmt.Println("Error reading file day3.txt")
		return
	}

	line := lines[0]

	// Part One
	r1, _ := regexp.Compile(`mul\((\d{1,3}),(\d{1,3})\)`)

	matches := r1.FindAllStringSubmatch(line, -1)

	sum1 := 0
	for _, match := range matches {
		a, _ := strconv.Atoi(match[1])
		b, _ := strconv.Atoi(match[2])
		sum1 += a * b
	}

	fmt.Printf("Day 3 Part 1: %v\n", sum1)

	// Part Two
	r2, _ := regexp.Compile(`(mul)\((\d{1,3}),(\d{1,3})\)|(do)\(\)|(don't)\(\)`)

	matches = r2.FindAllStringSubmatch(line, -1)

	sum2 := 0
	enabled := true
	for _, match := range matches {
		if match[1] == "mul" && enabled {
			a, _ := strconv.Atoi(match[2])
			b, _ := strconv.Atoi(match[3])
			sum2 += a * b
		} else if match[4] == "do" {
			enabled = true
		} else if match[5] == "don't" {
			enabled = false
		}
	}

	fmt.Printf("Day 3 Part 2: %v\n", sum2)
}
