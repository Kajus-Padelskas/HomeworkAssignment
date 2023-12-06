namespace HomeworkAssignment.Sorting.Strategies;

public class QuickSort : ISortStrategy
{
    public void Sort<T>(IList<T> items) where T : IComparable<T>
    {
        Sort(items, 0, items.Count() - 1);

        void Sort(IList<T> items, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(items, low, high);
                Sort(items, low, pivotIndex - 1);
                Sort(items, pivotIndex + 1, high);
            }
        }

        int Partition(IList<T> items, int low, int high)
        {
            T pivot = items[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (items[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    T temp = items[i];
                    items[i] = items[j];
                    items[j] = temp;
                }
            }

            T temp2 = items[i + 1];
            items[i + 1] = items[high];
            items[high] = temp2;

            return i + 1;
        }
    }
}
