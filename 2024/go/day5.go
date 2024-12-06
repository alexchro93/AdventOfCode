package main

import (
	"fmt"
	"strconv"
	"strings"

	"github.com/alexchro93/2024/go/utils"
)

type Update struct {
	pages []int
}

type Rule struct {
	first  int
	second int
}

type Input struct {
	rules   map[Rule]bool
	updates []Update
}

func ParseDay5Input() (*Input, error) {
	lines, err := utils.ReadAllLines("input/day5.txt")
	if err != nil {
		return nil, err
	}

	rules := make(map[Rule]bool, 0)
	updates := make([]Update, 0)

	parseRule := true
	for _, line := range lines {
		if line == "" {
			parseRule = false
			continue
		}

		if parseRule {
			parts := strings.Split(line, "|")
			first, err := strconv.Atoi(parts[0])
			if err != nil {
				return nil, err
			}
			second, err := strconv.Atoi(parts[1])
			if err != nil {
				return nil, err
			}
			rules[Rule{first, second}] = true
		} else {
			parts := strings.Split(line, ",")
			pages := make([]int, len(parts))
			for i, part := range parts {
				page, err := strconv.Atoi(part)
				if err != nil {
					return nil, err
				}
				pages[i] = page
			}
			updates = append(updates, Update{pages})
		}
	}

	return &Input{rules, updates}, nil
}

func ValidUpdate(update int, input *Input) (bool, int, int) {
	upd := input.updates[update]
	for i, page := range upd.pages {
		curr := page
		if i == 0 {
			continue
		}
		for j := i - 1; j >= 0; j-- {
			prev := upd.pages[j]
			if _, ok := input.rules[Rule{curr, prev}]; ok {
				return false, i, j
			}
		}
	}
	return true, 0, 0
}

func FixInvalid(update int, input *Input) bool {
	upd := input.updates[update]
	invalid := true
	count := 0
	for invalid && count < 1000 {
		valid, curr, prev := ValidUpdate(update, input)
		invalid = !valid
		if invalid {
			tmp := upd.pages[curr]
			upd.pages[curr] = upd.pages[prev]
			upd.pages[prev] = tmp
		}
		count++
	}

	return !invalid
}

func Day5() {
	input, err := ParseDay5Input()
	if err != nil {
		return
	}

	invalid := make([]int, 0)

	// Part One
	sum1 := 0
	for i, update := range input.updates {
		valid, _, _ := ValidUpdate(i, input)
		if valid {
			mid := len(update.pages) / 2
			sum1 += update.pages[mid]
		} else {
			invalid = append(invalid, i)
		}
	}

	fmt.Printf("Day 5 Part 1: %v\n", sum1)

	// Part Two
	sum2 := 0
	for _, i := range invalid {
		update := input.updates[i]
		fixed := FixInvalid(i, input)
		if fixed {
			mid := len(update.pages) / 2
			sum2 += update.pages[mid]
		} else {
			fmt.Println("Could not fix invalid update")
			return
		}
	}

	fmt.Printf("Day 5 Part 2: %v\n", sum2)
}
