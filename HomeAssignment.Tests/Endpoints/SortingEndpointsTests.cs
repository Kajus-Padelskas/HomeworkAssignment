using HomeworkAssignment.Api.Endpoints;
using HomeworkAssignment.Options;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace HomeworkAssignment.Tests.Endpoints;
public class SortingEndpointsTests(HomeworkAssignmentApiFactory factory) : IClassFixture<HomeworkAssignmentApiFactory>
{
    private const string SORT_ITEMS_ENDPOINT = EndpointConsts.SortingEndpoints.BASE_GROUP + EndpointConsts.SortingEndpoints.SORT_ITEMS;
    private const string GET_LATEST_SORT_RESULT_ENDPOINT = EndpointConsts.SortingEndpoints.BASE_GROUP + EndpointConsts.SortingEndpoints.GET_LATEST_SORT_RESULT;

    private readonly HomeworkAssignmentApiFactory _factory = factory;

    [Fact]
    public async Task SortItems_GivenValidNumberItems_ShouldReturn_200AndSortedItems()
    {
        var client = _factory.CreateClient();
        var expectedResult = new int[] { 0, 1, 2, 5, 6, 10 };

        var response = await client.PostAsJsonAsync(SORT_ITEMS_ENDPOINT, new int[] { 0, 2, 5, 1, 6, 10 });
        var result = JsonConvert.DeserializeObject<int[]>(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public async Task SortItems_GivenInValidNumberItemRange_ShouldReturn_400()
    {
        var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync(SORT_ITEMS_ENDPOINT, new int[] { 0, 2, 5, 1, 6, 10, 2, 5, 1, 5, 2 });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task SortItems_GivenNoNumberItems_ShouldReturn_400()
    {
        var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync(SORT_ITEMS_ENDPOINT, new { });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task SortItems_GivenNumberItemsWhereNumberIsAbove10_ShouldReturn_400()
    {
        var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync(SORT_ITEMS_ENDPOINT, new int[] { 0, 2, 5, 1, 6, 11 });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GetLatestSortedItems_GivenNumberItemsWereOrderedBySortItemsEndpoint_ShouldReturn_200AndLatestSortItemsEndpointResult()
    {
        var client = _factory.CreateClient();
        var sortItemsResponse = await client.PostAsJsonAsync(SORT_ITEMS_ENDPOINT, new int[] { 0, 2, 5, 1, 6, 6 });
        var sortedItems = JsonConvert.DeserializeObject<int[]>(await sortItemsResponse.Content.ReadAsStringAsync());

        var latestSortedItemsResponse = await client.GetAsync(GET_LATEST_SORT_RESULT_ENDPOINT);
        var result = JsonConvert.DeserializeObject<int[]>(await latestSortedItemsResponse.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, latestSortedItemsResponse.StatusCode);
        Assert.Equal(sortedItems, result);
    }

    [Fact]
    public async Task GetLatestSortedItems_GivenNumberItemsWereNotOrderedBySortItemsEndpoint_ShouldReturn_404()
    {
        var options = new SortingOptions();
        _factory.Configuration.GetSection(SortingOptions.Sorting).Bind(options);

        if (File.Exists(options.LatestSortedCollectionFileName))
        {
            File.Delete(options.LatestSortedCollectionFileName);
        }

        var client = _factory.CreateClient();

        var response = await client.GetAsync(GET_LATEST_SORT_RESULT_ENDPOINT);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
