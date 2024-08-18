namespace Algorithms.Search;

public static class RBinarySearch {
    // There is a non-null sorted array and some object target. Need to find max{i : container[i] <= target}
    public static int FindIndex<T>(T[] container, T target)
        where T : IComparable<T> {
        int left = -1;
        int right = container.Length;

        while (right - left > 1) {
            int mid = left + (right - left) / 2;
            if (target.CompareTo(container[mid]) >= 0) {
                left = mid;
            } else {
                right = mid;
            }
        }

        return left;
    }
}