using HomeworkAssignment.Api.Endpoints;
using HomeworkAssignment.DataManager;
using HomeworkAssignment.Options;
using HomeworkAssignment.Sorting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;

namespace HomeworkAssignment.Endpoints;

public static class SortingModule
{
    public static IEndpointRouteBuilder MapSortingEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup(EndpointConsts.SortingEndpoints.BASE_GROUP);

        group.MapPost(EndpointConsts.SortingEndpoints.SORT_ITEMS, SortItems).WithName(nameof(SortItems));

        group.MapGet(EndpointConsts.SortingEndpoints.GET_LATEST_SORT_RESULT, GetLatestSortedItems).WithName(nameof(GetLatestSortedItems));

        return builder;
    }

    public static async Task<Results<Ok<int[]>, BadRequest<string>>> SortItems(
        Sorter sorter,
        IDataManager fileManager,
        IOptions<SortingOptions> options,
        int[] items)
    {
        if (items is null || items.Length == 0)
        {
            return TypedResults.BadRequest("No values were passed");
        }

        if (items.Length > 10)
        {
            return TypedResults.BadRequest("The length of items can't exceed 10");
        }

        if (items.Any(x => x > 10 || x < 0))
        {
            return TypedResults.BadRequest("The size of a number can't exceed 10 and can't be below 0");
        }

        sorter.Sort(items);

        await fileManager.WriteAsync(options.Value.LatestSortedCollectionFileName, string.Join(" ",items));

        return TypedResults.Ok(items);
    }

    public static async Task<Results<Ok<int[]>, NotFound<string>>> GetLatestSortedItems(
        IDataManager fileManager,
        IOptions<SortingOptions> options,
        CancellationToken cancellationToken)
    {
        var result = await fileManager.ReadAllTextAsync(options.Value.LatestSortedCollectionFileName, cancellationToken);

        if (result is null)
        {
            return TypedResults.NotFound("No sorted items were found");
        }

        var latestSortedItems = result.Split(' ').Select(int.Parse).ToArray();

        return TypedResults.Ok(latestSortedItems);
    }
}
