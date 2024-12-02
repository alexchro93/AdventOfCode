package utils

import (
	"bufio"
	"os"
)

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
