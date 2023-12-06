using HomeworkAssignment.Api.Sorting;
using HomeworkAssignment.Options;
using HomeworkAssignment.Sorting;
using Xunit;

namespace HomeworkAssignment.Tests.Sorting;
public class SorterTests
{
    [Fact]
    public void Sort_UsingBubbleSort_ShouldSortItemsASC()
    {
        var options = Microsoft.Extensions.Options.Options.Create(new SortingOptions
        {
            SortingAlgorithm = SortingAlgorithms.BubbleSort
        });
        var sorter = new Sorter(options);
        var testData = new int[] { 7, 9, 1, 8, 5 };
        var expectedResult = new int[] { 1, 5, 7, 8, 9 };

        sorter.Sort(testData);

        Assert.Equal(expectedResult, testData);
    }

    [Fact]
    public void Sort_UsingQuickSort_ShouldSortItemsASC()
    {
        var options = Microsoft.Extensions.Options.Options.Create(new SortingOptions
        {
            SortingAlgorithm = SortingAlgorithms.QuickSort
        });
        var sorter = new Sorter(options);
        var testData = new int[] { 7, 9, 1, 8, 5 };
        var expectedResult = new int[] { 1, 5, 7, 8, 9 };

        sorter.Sort(testData);

        Assert.Equal(expectedResult, testData);
    }

    [Fact]
    public void Sort_UsingHeapSort_ShouldSortItemsASC()
    {
        var options = Microsoft.Extensions.Options.Options.Create(new SortingOptions
        {
            SortingAlgorithm = SortingAlgorithms.HeapSort
        });
        var sorter = new Sorter(options);
        var testData = new int[] { 7, 9, 1, 8, 5 };
        var expectedResult = new int[] { 1, 5, 7, 8, 9 };

        sorter.Sort(testData);

        Assert.Equal(expectedResult, testData);
    }
}
