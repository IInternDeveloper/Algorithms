namespace Algorithms.Sorting;

public static class InsertionSort {
    public static void Sort<T>(T[] container) where T : IComparable<T> {
        int containerSize = container.Length;
        for (int i = 1; i < containerSize; i++) {
            int j = i - 1;
            while (j >= 0 && container[j].CompareTo(container[j + 1]) > 0) {
                (container[j], container[j + 1]) = (container[j + 1], container[j]);
                j--;
            }
        }
    }
}