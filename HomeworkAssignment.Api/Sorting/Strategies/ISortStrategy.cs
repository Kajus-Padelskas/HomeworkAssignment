namespace HomeworkAssignment.Sorting.Strategies;

public interface ISortStrategy
{
    void Sort<T>(IList<T> items) where T : IComparable<T>;
}
