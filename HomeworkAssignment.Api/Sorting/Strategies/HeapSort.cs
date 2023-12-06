using HomeworkAssignment.Sorting.Strategies;

namespace HomeworkAssignment.Api.Sorting.Strategies;

public class HeapSort : ISortStrategy
{
    public void Sort<T>(IList<T> items) where T : IComparable<T>
    {
        int n = items.Count;

        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(items, n, i);
        }

        for (int i = n - 1; i > 0; i--)
        {
            Swap(items, 0, i);

            Heapify(items, i, 0);
        }

        void Heapify(IList<T> items, int n, int i)
        {
            int largest = i;
            int leftChild = 2 * i + 1;
            int rightChild = 2 * i + 2;

            if (leftChild < n && items[leftChild].CompareTo(items[largest]) > 0)
            {
                largest = leftChild;
            }

            if (rightChild < n && items[rightChild].CompareTo(items[largest]) > 0)
            {
                largest = rightChild;
            }

            if (largest != i)
            {
                Swap(items, i, largest);

                Heapify(items, n, largest);
            }
        }

        void Swap(IList<T> items, int i, int j)
        {
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
