namespace Dub.Sorting;

public static class Sort
{
    // In production I'd use more generic interfaces like IReadOnlyList<T> or IEnumerable<T>. 
    // Here I just wanted to play with ArraySegments and ranges and they work best with a simple array type
    public static T[] MergeSort<T>(this T[] src)
        where T : IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(src);

        var segment = new ArraySegment<T>(src);
        return MergeSort(segment).ToArray();
    }

    private static ArraySegment<T> MergeSort<T>(ArraySegment<T> src)
        where T : IComparable<T>
    {
        if (src.Count <= 1)
        {
            return src;
        }

        var mid = src.Count / 2;

        var left = MergeSort(src[..mid]);
        var right = MergeSort(src[mid..]);

        return Merge(left, right);
    }

    private static ArraySegment<T> Merge<T>(ArraySegment<T> left, ArraySegment<T> right)
        where T : IComparable<T>
    {
        var result = new T[left.Count + right.Count];
        int i = 0, l = 0, r = 0;

        while (l < left.Count && r < right.Count)
        {
            var next = left[l].CompareTo(right[r]) < 0 ? left[l++] : right[r++];
            result[i++] = next;
        }

        while (l < left.Count)
        {
            result[i++] = left[l++];
        }

        while (r < right.Count)
        {
            result[i++] = right[r++];
        }

        return result;
    }
}