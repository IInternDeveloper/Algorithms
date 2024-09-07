using System.Collections;

namespace Algorithms.Containers;

public class Stack<T> : IEnumerable<T> {
    private T[] _container;
    private int _capacity;

    private const int _defaultCapacity = 4;

    public int Count { get; private set; } = 0;
    public bool IsEmpty => Count == 0;
    
    public Stack() : this(_defaultCapacity) {
        
    }

    public Stack(int capacity) {
        ArgumentOutOfRangeException.ThrowIfNegative(capacity);

        _capacity = capacity;
        _container = new T[_capacity];
    }

    public Stack(IEnumerable<T> enumerable) {
        ArgumentNullException.ThrowIfNull(enumerable);

        _capacity = enumerable.Count();
        _container = new T[_capacity];

        foreach (var item in enumerable) {
            Push(item);
        }
    }

    public void Push(T item) {
        if (Count == _capacity) {
            _capacity *= 2;
            Array.Resize(ref _container, _capacity);
        }

        _container[Count++] = item;
    }

    public T Pop() {
        if (IsEmpty) {
            throw new InvalidOperationException("Stack is empty.");
        }

        var top = _container[Count - 1];
        _container[--Count] = default!;

        return top;
    }

    public T Peek() {
        if (IsEmpty) {
            throw new InvalidOperationException("Stack is empty.");
        }

        return _container[Count - 1];
    }

    public bool Contains(T item) {
        for (int i = Count - 1; i >= 0; i--) {
            if (_container[i].Equals(item)) {
                return true;
            }
        }

        return false;
    }

    public void Clear() {
        Array.Clear(_container, 0, Count);
        Count = 0;
    }

    public T[] ToArray() {
        var array = new T[Count];
        for (int i = 0; i < Count; i++) {
            array[i] = _container[Count - 1 - i];
        }

        return array;
    }

    public IEnumerator<T> GetEnumerator() {
        for (int i = Count - 1; i >= 0; i--) {
            yield return _container[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}