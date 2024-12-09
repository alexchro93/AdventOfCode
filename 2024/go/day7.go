package main

import (
	"fmt"
	"strconv"
	"strings"

	"github.com/alexchro93/2024/go/utils"
)

func ParseDay7Input() (map[int][]int, error) {
	lines, err := utils.ReadAllLines("input/day7.txt")
	if err != nil {
		return nil, err
	}

	data := make(map[int][]int)

	for _, line := range lines {
		parts := strings.Split(line, ":")

		key, err := strconv.Atoi(parts[0])
		if err != nil {
			return nil, err
		}

		parts[1] = strings.TrimSpace(parts[1])
		values := strings.Split(parts[1], " ")
		for _, value := range values {
			v, err := strconv.Atoi(value)
			if err != nil {
				return nil, err
			}
			data[key] = append(data[key], v)
		}
	}

	return data, nil
}

func FindValues(input []int, eval, pos int, concat bool) []int {
	if pos >= len(input) {
		return []int{eval}
	}

	values := make([]int, 0)

	sum := eval + input[pos]
	values = append(values, FindValues(input, sum, pos+1, concat)...)

	product := eval * input[pos]
	values = append(values, FindValues(input, product, pos+1, concat)...)

	if concat {
		concatenated, err := strconv.Atoi(strconv.Itoa(eval) + strconv.Itoa(input[pos]))
		if err != nil {
			panic(err)
		}
		values = append(values, FindValues(input, concatenated, pos+1, concat)...)
	}

	return values
}

func Day7() {
	input, err := ParseDay7Input()
	if err != nil {
		return
	}

	// Part One
	sum1 := 0
	for key, value := range input {
		candidates := FindValues(value, value[0], 1, false)
		for _, candidate := range candidates {
			if candidate == key {
				sum1 += key
				break
			}
		}
	}

	fmt.Printf("Day 7 Part 1: %v\n", sum1)

	// Part Two
	sum2 := 0
	for key, value := range input {
		candidates := FindValues(value, value[0], 1, true)
		for _, candidate := range candidates {
			if candidate == key {
				sum2 += key
				break
			}
		}
	}

	fmt.Printf("Day 7 Part 2: %v\n", sum2)
}
