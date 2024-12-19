package main

import (
	"fmt"
	"os"
	"strconv"
)

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
		Day1()
	case 2:
		Day2()
	case 3:
		Day3()
	case 4:
		Day4()
	case 5:
		Day5()
	case 6:
		Day6()
	case 7:
		Day7()
	case 8:
		Day8()
	case 9:
		Day9()
	case 10:
		Day10()
	case 11:
		Day11()
	case 12:
		Day12()
	case 13:
		Day13()
	case 14:
		Day14()
	case 15:
		Day15()
	default:
		fmt.Println("Day not implemented")
	}
}
