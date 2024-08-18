namespace Algorithms.Search;

public static class BinarySearch {
    // There is a non-null sorted array with unique elements and some object target. Need to find i : container[i] == target
    public static int FindIndex<T>(T[] container, T target)
        where T : IComparable<T> {
        int left = 0;
        int right = container.Length - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            int comparison = target.CompareTo(container[mid]);

            if (comparison < 0) {
                right = mid - 1;
                continue;
            }

            if (comparison > 0) {
                left = mid + 1;
                continue;
            }

            return mid;
        }

        return -1;
    }
}