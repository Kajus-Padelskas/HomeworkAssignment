using HomeworkAssignment.Api.Sorting;

namespace HomeworkAssignment.Options;

public class SortingOptions
{
    public const string Sorting = "Sorting";

    public string LatestSortedCollectionFileName { get; set; } = "LatestSortedCollectionFileName.txt";

    public SortingAlgorithms SortingAlgorithm { get; set; } = SortingAlgorithms.BubbleSort;
}
