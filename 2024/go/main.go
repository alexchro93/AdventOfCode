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
	default:
		fmt.Println("Day not implemented")
	}
}
