using System.Collections;

namespace Algorithms.Lists.SinglyLinkedList;

public class SinglyLinkedList<T> : IEnumerable<T> {
    public Node<T>? Head { get; private set; }
    public Node<T>? Tail { get; private set; }

    public int Count { get; private set; }

    public SinglyLinkedList() {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public void AddFirst(T data) {
        var node = new Node<T>(data);

        if (Head is null) {
            Head = node;
            Tail = node;
        } else {
            node.Next = Head;
            Head = node;
        }

        Count++;
    }

    public void AddLast(T data) {
        var node = new Node<T>(data);

        if (Head is null) {
            Head = node;
            Tail = node;
        } else {
            Tail.Next = node;
            Tail = node;
        }

        Count++;
    }

    public void AddAfter(Node<T> after, T data) {
        var node = new Node<T>(data);
        node.Next = after.Next;
        after.Next = node;

        if (after == Tail) {
            Tail = node;
        }

        Count++;
    }

    public void RemoveFirst() {
        if (Head is null) {
            throw new InvalidOperationException("The linked list is empty.");
        }

        Head = Head.Next;
        if (Head is null) {
            Tail = null;
        }

        Count--;
    }

    public void RemoveLast() {
        if (Head is null) {
            throw new InvalidOperationException("The linked list is empty.");
        }

        if (Head == Tail) {
            Head = null;
            Tail = null;
        } else {
            var current = Head;
            while (current.Next != Tail) {
                current = current.Next;
            }
            current.Next = null;
            Tail = current;
        }

        Count--;
    }

    public void Remove(Node<T> removed) {
        if (Head is null) {
            throw new InvalidOperationException("The linked list is empty.");
        }

        var current = Head;
        while (current.Next is not null && current.Next != removed) {
            current = current.Next;
        }

        if (current.Next is null) {
            throw new InvalidOperationException("Node not found in the linked list.");
        }

        current.Next = removed.Next;

        if (removed == Tail) {
            Tail = current;
        }

        Count--;
    }

    public Node<T>? Find(T data) {
        var current = Head;
        while (current is not null) {
            if (current.Data.Equals(data)) {
                return current;
            }

            current = current.Next;
        }

        return null;
    }

    public bool Contains(T data) {
        return Find(data) is not null;
    }

    public void Clear() {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public IEnumerator<T> GetEnumerator() {
        var current = Head;
        while (current is not null) {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}