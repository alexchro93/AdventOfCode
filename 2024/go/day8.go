package main

import (
	"fmt"

	"github.com/alexchro93/2024/go/utils"
)

func ParseDay8Input() ([][]rune, error) {
	lines, err := utils.ReadAllLines("input/day8.txt")
	if err != nil {
		return nil, err
	}

	data := make([][]rune, len(lines))

	for i, line := range lines {
		data[i] = []rune(line)
	}

	return data, nil
}

func Day8() {
	input, err := ParseDay8Input()
	if err != nil {
		return
	}

	maxX := len(input[0])
	maxY := len(input)

	// Part One
	seen := make(map[rune][]utils.Point)
	antinodes := make(map[utils.Point]int)

	for i := 0; i < maxY; i++ {
		for j := 0; j < maxX; j++ {
			antenna := input[i][j]
			if antenna == '.' {
				continue
			}
			locations, ok := seen[antenna]
			if !ok {
				seen[antenna] = make([]utils.Point, 0)
			} else {
				for _, loc := range locations {
					distX := j - loc.X
					distY := i - loc.Y

					p1 := utils.Point{X: loc.X - distX, Y: loc.Y - distY}
					p2 := utils.Point{X: j + distX, Y: i + distY}

					if p1.X >= 0 && p1.X < maxX && p1.Y >= 0 && p1.Y < maxY {
						antinodes[p1]++
					}
					if p2.X >= 0 && p2.X < maxX && p2.Y >= 0 && p2.Y < maxY {
						antinodes[p2]++
					}
				}
			}
			seen[antenna] = append(seen[antenna], utils.Point{X: j, Y: i})
		}
	}

	fmt.Printf("Day 8 Part 1: %v\n", len(antinodes))

	// Part One
	seen = make(map[rune][]utils.Point)
	antinodes = make(map[utils.Point]int)

	for i := 0; i < maxY; i++ {
		for j := 0; j < maxX; j++ {
			antenna := input[i][j]
			if antenna == '.' {
				continue
			}
			locations, ok := seen[antenna]
			if !ok {
				seen[antenna] = make([]utils.Point, 0)
			} else {
				for _, loc := range locations {
					antinodes[loc]++
					antinodes[utils.Point{X: j, Y: i}]++

					distX := j - loc.X
					distY := i - loc.Y

					p1 := utils.Point{X: loc.X - distX, Y: loc.Y - distY}
					for p1.X >= 0 && p1.X < maxX && p1.Y >= 0 && p1.Y < maxY {
						antinodes[p1]++
						p1.X -= distX
						p1.Y -= distY
					}

					p2 := utils.Point{X: j + distX, Y: i + distY}
					for p2.X >= 0 && p2.X < maxX && p2.Y >= 0 && p2.Y < maxY {
						antinodes[p2]++
						p2.X += distX
						p2.Y += distY
					}
				}
			}
			seen[antenna] = append(seen[antenna], utils.Point{X: j, Y: i})
		}
	}

	fmt.Printf("Day 8 Part 2: %v\n", len(antinodes))
}
