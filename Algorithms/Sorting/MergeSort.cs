namespace Algorithms.Sorting;

public static class MergeSort<T> where T : IComparable<T> {
    public static void Sort(T[] container) {
        Sort(container, 0, container.Length);
    }

    private static void Sort(T[] container, int left, int right) {
        if (right - left <= 1) {
            return;
        }

        int mid = left + (right - left) / 2;
        Sort(container, left, mid);
        Sort(container, mid, right);

        Merge(container, left, mid, right);
    }

    private static void Merge(T[] container, int left, int mid, int right) {
        T[] merged = new T[right - left];

        int i = left, j = mid;
        while (i < mid || j < right) {
            int mergedIndex = (i - left) + (j - mid);
            if (j == right || (i < mid && container[i].CompareTo(container[j]) < 0)) {
                merged[mergedIndex] = container[i++];
            } else {
                merged[mergedIndex] = container[j++];
            }
        }

        Array.Copy(merged, 0, container, left, merged.Length);
    }
}