namespace Algorithms.Sorting;

public static class BubbleSort {
    public static void Sort<T>(T[] container) where T : IComparable<T> {
        int containerSize = container.Length;
        for (int i = containerSize - 1; i > 0; i--) {
            bool swapped = false;
            for (int j = 0; j < i; j++) {
                if (container[j].CompareTo(container[j + 1]) > 0) {
                    (container[j], container[j + 1]) = (container[j + 1], container[j]);
                    swapped = true;
                }
            }
            
            if (!swapped) {
                break;
            }
        }
    }
}