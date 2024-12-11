package utils

import (
	"bufio"
	"os"

	"golang.org/x/exp/constraints"
)

type Point struct {
	X, Y int
}

// Places the contents of src in to dst.
func MergeMaps[K comparable, V constraints.Integer](dst, src map[K]V) {
	for key, value := range src {
		dst[key] += value
	}
}

// Reads all lines from a file and returns them as a slice of strings.
// If there's a problem opening the file, an error is returned.
func ReadAllLines(name string) ([]string, error) {
	file, err := os.Open(name)
	if err != nil {
		return nil, err
	}
	defer file.Close()

	lines := make([]string, 0)
	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		lines = append(lines, scanner.Text())
	}

	return lines, nil
}
