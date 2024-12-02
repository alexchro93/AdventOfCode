package main

import (
	"bufio"
	"fmt"
	"os"
	"sort"
	"strconv"
	"strings"
)

func day1() {
	// Part One
	file, err := os.Open("input/day1.txt")
	if err != nil {
		fmt.Println("Error reading file 'input/day1.txt'")
		return
	}
	defer file.Close()

	left := []int{}
	right := []int{}

	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		line := scanner.Text()

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

func main() {
	if len(os.Args) != 2 {
		fmt.Println("Usage: solutions <day>")
		return
	}

	day, err := strconv.Atoi(os.Args[1])
	if err != nil {
		fmt.Println("Invalid day:", os.Args[1])
		return
	}

	switch day {
	case 1:
		day1()
	default:
		fmt.Println("Day not implemented")
	}
}
