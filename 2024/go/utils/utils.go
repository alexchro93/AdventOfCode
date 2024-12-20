package utils

import (
	"bufio"
	"fmt"
	"os"

	"golang.org/x/exp/constraints"
)

type Point struct {
	X, Y int
}

// A queue for holding a specific type
type Queue[T any] []T

// Pushes an element on to the queue.
func (self *Queue[T]) Push(x T) {
	*self = append(*self, x)
}

// Determines if the queue is empty.
func (self *Queue[T]) Empty() bool {
	return len(*self) == 0
}

// Pops an element from the queue.
func (self *Queue[T]) Pop() T {
	h := *self
	var el T
	l := len(h)
	el, *self = h[0], h[1:l]
	// Or use this instead for a Stack
	// el, *self = h[l-1], h[0:l-1]
	return el
}

// Creates a new queue.
func NewQueue[T any](items ...T) *Queue[T] {
	if items == nil {
		return &Queue[T]{}
	}
	queue := &Queue[T]{}
	for _, item := range items {
		queue.Push(item)
	}
	return queue
}

// Node in a doubly-linked list.
type Node[T any] struct {
	next  *Node[T]
	prev  *Node[T]
	Value T
}

// Represents the doubly-linked list that allows
// only forward iteration (i.e. head to tail).
type DoublyLinkedList[T any] struct {
	head   *Node[T]
	tail   *Node[T]
	length int
}

// Insert adds a new node at the end of the list.
func (list *DoublyLinkedList[T]) Insert(data T) {
	newNode := &Node[T]{Value: data}
	if list.head == nil {
		list.head = newNode
		list.tail = newNode
	} else {
		list.tail.next = newNode
		newNode.prev = list.tail
		list.tail = newNode
	}
	list.length++
}

// Replaces the current node with two nodes containing new values.
func (list *DoublyLinkedList[T]) Replace(node *Node[T], first, second T) {
	n1 := &Node[T]{Value: first}
	n2 := &Node[T]{Value: second}

	if node.prev != nil {
		node.prev.next = n1
	} else {
		list.head = n1
	}
	n1.prev = node.prev
	n1.next = n2

	n2.prev = n1
	n2.next = node.next
	if node.next != nil {
		node.next.prev = n2
	} else {
		list.tail = n2
	}

	list.length++
}

// Count returns the number of nodes in the list.
func (list *DoublyLinkedList[T]) Count() int {
	return list.length
}

// An iterator for a doubly-linked list.
type DoublyLinkedListIterator[T any] struct {
	List    *DoublyLinkedList[T]
	current *Node[T]
}

// Determines if there's more items to iterate over.
func (iter *DoublyLinkedListIterator[T]) More() bool {
	if iter.current == nil {
		iter.current = iter.List.head
	} else {
		iter.current = iter.current.next
	}
	return iter.current != nil
}

// Gets the current iterator item.
func (iter *DoublyLinkedListIterator[T]) Value() *Node[T] {
	return iter.current
}

// Gets the current iterator item.
func (iter *DoublyLinkedListIterator[T]) Reset() {
	iter.current = nil
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

// Prints the grid to the console.
func PrintGrid(grid [][]rune) {
	yMax := len(grid)
	xMax := len(grid[0])
	for j := 0; j < yMax; j++ {
		for i := 0; i < xMax; i++ {
			fmt.Printf("%c", grid[j][i])
		}
		fmt.Print("\n")
	}
}
