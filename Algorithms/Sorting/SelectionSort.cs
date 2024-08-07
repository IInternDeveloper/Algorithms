namespace Algorithms.Sorting;

public static class SelectionSort {
    public static void Sort<T>(T[] container)
        where T : IComparable<T> {
        int containerSize = container.Length;
        for (int i = 0; i < containerSize - 1; i++) {
            int indexMin = i;
            for (int j = i + 1; j < containerSize; j++) {
                if (container[indexMin].CompareTo(container[j]) > 0) {
                    indexMin = j;
                }
            }
            (container[i], container[indexMin]) = (container[indexMin], container[i]);
        }
    }
}
