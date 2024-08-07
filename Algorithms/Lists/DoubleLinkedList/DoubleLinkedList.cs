using System.Collections;

namespace Algorithms.Lists.DoubleLinkedList;

public class DoubleLinkedList<T> : IEnumerable<T> {
    public Node<T>? Head { get; private set; }
    public Node<T>? Tail { get; private set; }

    public int Count { get; private set; }

    public DoubleLinkedList() {
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
            Head.Previous = node;
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
            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;
        }

        Count++;
    }

    public void AddAfter(Node<T> after, T data) {
        var node = new Node<T>(data);
        var next = after.Next;

        after.Next = node;
        node.Previous = after;
        node.Next = next;

        if (next is null) {
            Tail = node;
        } else {
            next.Previous = node;
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
        } else {
            Head.Previous = null;
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
            Tail = Tail.Previous;
            Tail.Next = null;
        }

        Count--;
    }

    public void Remove(Node<T> removed) {
        if (Head is null) {
            throw new InvalidOperationException("The linked list is empty.");
        }
        
        if (removed == Head) {
            Head = removed.Next;
        } else {
            removed.Previous.Next = removed.Next;
        }

        if (removed == Tail) {
            Tail = removed.Previous;
        } else {
            removed.Next.Previous = removed.Previous;
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