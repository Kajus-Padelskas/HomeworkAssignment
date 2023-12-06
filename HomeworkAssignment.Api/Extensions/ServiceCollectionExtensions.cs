using HomeworkAssignment.DataManager;
using HomeworkAssignment.Options;
using HomeworkAssignment.Sorting;

namespace HomeworkAssignment.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<Sorter>();

        services.AddScoped<IDataManager, FileManager>();

        services.Configure<SortingOptions>(configuration.GetSection(SortingOptions.Sorting));

        return services;
    }
}
