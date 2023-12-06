using HomeworkAssignment.Api.Sorting;
using HomeworkAssignment.Sorting;
using HomeworkAssignment.Sorting.Strategies;
using Xunit;

namespace HomeworkAssignment.Tests.Sorting;
public class SorterFactoryTests
{
    [Fact]
    public void Create_GivenBubbleSortAlgorithmArgument_ShouldCreateSorterOfTypeBubbleSort()
    {
        ISortStrategy sortingStrategy = SorterFactory.Create(SortingAlgorithms.BubbleSort);

        Assert.IsType<BubbleSort>(sortingStrategy);
    }

    [Fact]
    public void Create_GivenBubbleSortAlgorithmArgument_ShouldCreateSorterOfTypeQuickSort()
    {
        ISortStrategy sortingStrategy = SorterFactory.Create(SortingAlgorithms.QuickSort);

        Assert.IsType<QuickSort>(sortingStrategy);
    }
}
