using HomeworkAssignment.Options;
using Microsoft.Extensions.Options;

namespace HomeworkAssignment.Sorting;

public class Sorter(IOptions<SortingOptions> options)
{
    private readonly SortingOptions _options = options.Value;

    public void Sort<T>(IList<T> items) where T : IComparable<T>
    {
        var sortingStrategy = SorterFactory.Create(this._options.SortingAlgorithm);

        sortingStrategy.Sort(items);
    }
}
