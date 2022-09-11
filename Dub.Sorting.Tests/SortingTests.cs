namespace Dub.Sorting.Tests;

public class SortingTests
{
    private const int MaxArrayLength = 5000;

    [Fact]
    public void EvenArrayLength_ShouldReturnSortedArray()
    {
        int[] origin = { 8, 2, 33, 43, 12, -13, 0, 4 };
        var actual = origin.MergeSort();
        CheckSorted(actual);
    }

    [Fact]
    public void OddArrayLength_ShouldReturnSortedArray()
    {
        int[] origin = { 8, 2, 33, 43, 12, -13, 0, 4, 7 };
        var actual = origin.MergeSort();
        CheckSorted(actual);
    }

    [Fact]
    public void ContainingMaxAndMinValue_ShouldReturnSortedArray()
    {
        int[] origin = { 8, 2, 33, int.MinValue, 43, int.MaxValue, -13, 0, 4 };
        var actual = origin.MergeSort();
        CheckSorted(actual);
    }

    [Fact]
    public void PassingLargeArray_ShouldReturnSortedArray()
    {
        // Sorry for this random generator
        // In production I'd use a pre-generated file with values
        var src = Enumerable
            .Range(0, MaxArrayLength)
            .Select(_ => Random.Shared.Next(int.MinValue, int.MaxValue))
            .ToArray();

        var actual = src.MergeSort();

        CheckSorted(actual);
    }
    
    [Fact]
    public void PassingNullArgument_ShouldThrow()
    {
        int[]? src = null;
        Assert.Throws<ArgumentNullException>(() => src!.MergeSort());
    }
    
    [Fact]
    public void SortEmptyArray_ShouldNotReturnNull()
    {
        var src = Array.Empty<int>();
        var actual = src.MergeSort();
        
        Assert.Equal(actual, Array.Empty<int>());
    }

    private static void CheckSorted(IReadOnlyList<int> src)
    {
        Assert.NotNull(src);
        
        // check only for ascending 
        for (var i = 1; i < src.Count; i++)
        {
            if (src[i - 1] > src[i])
            {
                // sorry, should have printed where the array started to decrease
                // but it would require more time to implement
                Assert.True(false, "Enumerable is not sorted");
            }
        }
    }
}