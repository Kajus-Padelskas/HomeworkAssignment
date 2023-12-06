using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using HomeworkAssignment.Api.Sorting.Strategies;
using HomeworkAssignment.Sorting.Strategies;

namespace HomeworkAssignment.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class SortingAlgorithmsBenchmarks
{
    [Params(1000, 10000, 100000)]
    public int itemsSize;
    private readonly List<int> Items = new List<int>();

    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random();
        for (int i = 0; i < itemsSize; i++)
        {
            Items.Add(random.Next(1, 1000));
        }
    }


    [Benchmark]
    public void BubbleSortList()
    {
        var bubbleSort = new BubbleSort();
        bubbleSort.Sort(new List<int>(Items));
    }

    [Benchmark]
    public void QuickSortList()
    {
        var quickSort = new QuickSort();
        quickSort.Sort(new List<int>(Items));
    }

    [Benchmark]
    public void HeapSortList()
    {
        var heapSort = new HeapSort();
        heapSort.Sort(new List<int>(Items));
    }
}
