package utils

import (
	"bufio"
	"os"

	"golang.org/x/exp/constraints"
)

type Point struct {
	X, Y int
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
