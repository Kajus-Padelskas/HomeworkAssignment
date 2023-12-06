using HomeworkAssignment.Api.Sorting;
using HomeworkAssignment.Api.Sorting.Strategies;
using HomeworkAssignment.Sorting.Strategies;

namespace HomeworkAssignment.Sorting;

public static class SorterFactory
{
    public static ISortStrategy Create(SortingAlgorithms algorithm)
    {
        ISortStrategy chosenSortingStrategy = algorithm switch
        {
            SortingAlgorithms.BubbleSort => new BubbleSort(),
            SortingAlgorithms.QuickSort => new QuickSort(),
            SortingAlgorithms.HeapSort => new HeapSort(),
            _ => throw new NotImplementedException()
        };

        return chosenSortingStrategy;
    }
}