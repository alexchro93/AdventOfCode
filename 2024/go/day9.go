package main

import (
	"fmt"
	"strconv"

	"github.com/alexchro93/2024/go/utils"
)

func MakeDisk(input string) []string {
	disk := make([]string, 0)
	for i, r := range input {
		var item string
		if i%2 == 0 {
			item = strconv.Itoa(i / 2)
		} else {
			item = "."
		}
		size := int(r - '0')
		for j := 0; j < size; j++ {
			disk = append(disk, item)
		}
	}
	return disk
}

func CompactDisk(disk []string) []string {
	start := 0
	end := len(disk) - 1

	for start < end {
		if disk[start] != "." {
			start++
		} else if disk[end] == "." {
			end--
		} else {
			disk[start], disk[end] = disk[end], disk[start]
			start++
			end--
		}
	}

	return disk
}

func FindFreeSpace(disk []string, start, size, limit int) (int, error) {
	inSpace := false
	for i := start; i < limit; i++ {
		if disk[i] != "." {
			inSpace = false
			continue
		}
		if !inSpace {
			start = i
			inSpace = true
		}
		if i-start+1 >= size {
			return start, nil
		}
	}
	return 0, fmt.Errorf("no free space found")
}

func FindFile(disk []string, start int) (int, int, error) {
	inFile := false
	name := ""
	for i := start; i >= 0; i-- {
		if inFile {
			if disk[i] != name {
				return start, i + 1, nil
			}
		} else if disk[i] != "." {
			inFile = true
			name = disk[i]
			start = i
		}
	}

	if inFile {
		return start, 0, nil
	} else {
		return 0, 0, fmt.Errorf("no file found")
	}
}

func CompactDiskChunk(disk []string) []string {
	done := false
	start := len(disk) - 1
	for !done {
		fStart, fEnd, err := FindFile(disk, start)
		fileSize := fStart - fEnd + 1
		if err != nil {
			done = true
		} else {
			sStart, err := FindFreeSpace(disk, 0, fileSize, fEnd)
			if err == nil {
				for i := 0; i < fileSize; i++ {
					disk[sStart+i], disk[fStart-i] = disk[fStart-i], disk[sStart+i]
				}
			}
			start = fEnd - 1
		}
	}
	return disk
}

func GetChecksum(disk []string) (int, error) {
	checksum := 0
	for i, item := range disk {
		if item == "." {
			continue
		}
		val, err := strconv.Atoi(item)
		if err != nil {
			return 0, err
		} else {
			checksum += i * val
		}
	}
	return checksum, nil
}

func Day9() {
	inp, err := utils.ReadAllLines("input/day9.txt")
	if err != nil {
		return
	}

	// Part One
	disk := MakeDisk(inp[0])
	disk = CompactDisk(disk)
	checksum, err := GetChecksum(disk)
	if err != nil {
		return
	}

	fmt.Printf("Day 9 Part 1: %v\n", checksum)

	// Part Two
	disk = MakeDisk(inp[0])
	disk = CompactDiskChunk(disk)
	checksum, err = GetChecksum(disk)
	if err != nil {
		return
	}

	fmt.Printf("Day 9 Part 2: %v\n", checksum)
}
