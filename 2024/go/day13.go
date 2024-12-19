package main

import (
	"fmt"
	"math"
	"regexp"
	"strconv"

	"github.com/alexchro93/2024/go/utils"
)

/*
	Special thanks to the following Reddit post: https://www.reddit.com/r/adventofcode/comments/1hd7irq/2024_day_13_an_explanation_of_the_mathematics/
*/

type button struct {
	x, y float64
}

type prize struct {
	x, y float64
}

type machine struct {
	a, b  button
	prize prize
}

func ParseDay13Input() ([]machine, error) {
	lines, err := utils.ReadAllLines("input/day13.txt")
	if err != nil {
		return nil, err
	}

	input := make([]machine, 0)
	a := regexp.MustCompile(`Button A: X\+(?<x>\d+), Y\+(?<y>\d+)`)
	b := regexp.MustCompile(`Button B: X\+(?<x>\d+), Y\+(?<y>\d+)`)
	p := regexp.MustCompile(`Prize: X=(?<x>\d+), Y=(?<y>\d+)`)
	m := machine{}
	for i, line := range lines {
		if match := a.FindStringSubmatch(line); match != nil {
			x, err := strconv.ParseFloat(match[1], 64)
			if err != nil {
				return nil, err
			}
			y, err := strconv.ParseFloat(match[2], 64)
			if err != nil {
				return nil, err
			}
			m.a = button{x, y}
		}

		if match := b.FindStringSubmatch(line); match != nil {
			x, err := strconv.ParseFloat(match[1], 64)
			if err != nil {
				return nil, err
			}
			y, err := strconv.ParseFloat(match[2], 64)
			if err != nil {
				return nil, err
			}
			m.b = button{x, y}
		}

		if match := p.FindStringSubmatch(line); match != nil {
			x, err := strconv.ParseFloat(match[1], 64)
			if err != nil {
				return nil, err
			}
			y, err := strconv.ParseFloat(match[2], 64)
			if err != nil {
				return nil, err
			}
			m.prize = prize{x, y}
		}

		if line == "" || i == len(lines)-1 {
			input = append(input, m)
			m = machine{}
		}
	}

	return input, nil
}

func Day13() {
	input, err := ParseDay13Input()
	if err != nil {
		return
	}

	// Part One
	var sum1 int = 0
	for _, m := range input {
		a := (m.prize.x*m.b.y - m.prize.y*m.b.x) / (m.a.x*m.b.y - m.a.y*m.b.x)
		b := (m.a.x*m.prize.y - m.a.y*m.prize.x) / (m.a.x*m.b.y - m.a.y*m.b.x)
		if a == float64(int(a)) && b == float64(int(b)) {
			sum1 += 3*int(a) + int(b)
		}
	}

	fmt.Printf("Day 13 Part 1: %v\n", sum1)

	// Part Two
	var sum2 int64 = 0
	for _, m := range input {
		m.prize.x += 10000000000000
		m.prize.y += 10000000000000
		a := (m.prize.x*m.b.y - m.prize.y*m.b.x) / (m.a.x*m.b.y - m.a.y*m.b.x)
		b := (m.a.x*m.prize.y - m.a.y*m.prize.x) / (m.a.x*m.b.y - m.a.y*m.b.x)
		if math.Mod(a, 1) == 0 && math.Mod(b, 1) == 0 {
			sum2 += 3*int64(a) + int64(b)
		}
	}

	fmt.Printf("Day 13 Part 2: %v\n", sum2)
}
