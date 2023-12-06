namespace HomeworkAssignment.Sorting.Strategies;

public class BubbleSort : ISortStrategy
{
    public void Sort<T>(IList<T> list) where T : IComparable<T>
    {
        int n = list.Count;
        bool swapped;

        do
        {
            swapped = false;
            for (int i = 1; i < n; i++)
            {
                if (list[i - 1].CompareTo(list[i]) > 0)
                {
                    T temp = list[i - 1];
                    list[i - 1] = list[i];
                    list[i] = temp;
                    swapped = true;
                }
            }
            n--;
        } while (swapped);
    }
}
