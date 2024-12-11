package main

import (
	"fmt"
	"strconv"
	"strings"

	"github.com/alexchro93/2024/go/utils"
)

type key struct {
	level int
	val   int
}

func ParseDay11Input() ([]int, error) {
	lines, err := utils.ReadAllLines("input/day11.txt")
	if err != nil {
		return nil, err
	}
	list := make([]int, 0)
	items := strings.Fields(lines[0])
	for _, item := range items {
		val, err := strconv.Atoi(item)
		if err != nil {
			return nil, err
		}
		list = append(list, val)
	}
	return list, nil
}

func FindCount(val, level, target int, seen map[key]int) int {
	if level > target {
		return 1
	}

	key := key{level: level, val: val}
	if count, ok := seen[key]; ok {
		return count
	}

	if val == 0 {
		seen[key] = FindCount(1, level+1, target, seen)
		return seen[key]
	}

	str := strconv.Itoa(val)
	mid, rem := len(str)/2, len(str)%2
	if rem == 0 {
		one, _ := strconv.Atoi(str[:mid])
		two, _ := strconv.Atoi(str[mid:])

		vOne := FindCount(one, level+1, target, seen)
		vTwo := FindCount(two, level+1, target, seen)

		seen[key] = vOne + vTwo
		return seen[key]
	} else {
		seen[key] = FindCount(val*2024, level+1, target, seen)
		return seen[key]
	}
}

func Day11() {
	list, err := ParseDay11Input()
	if err != nil {
		return
	}

	// Part One
	sum := 0
	seen := make(map[key]int)
	for _, val := range list {
		sum += FindCount(val, 1, 25, seen)
	}

	fmt.Printf("Day 11 Part 1: %v\n", sum)

	// Part Two
	sum = 0
	seen = make(map[key]int)
	for _, val := range list {
		sum += FindCount(val, 1, 75, seen)
	}

	fmt.Printf("Day 11 Part 2: %v\n", sum)
}
