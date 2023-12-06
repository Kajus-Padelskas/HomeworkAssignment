using HomeworkAssignment.Api;
using HomeworkAssignment.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace HomeworkAssignment.Tests;
public class HomeworkAssignmentApiFactory : WebApplicationFactory<IAssemblyMarker>
{
    public IConfiguration Configuration { get; set; } = null!;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((context, configBuilder) =>
        {
            Configuration = configBuilder.AddJsonFile(Environment.CurrentDirectory + "\\appsettings.Tests.json", optional: false).Build();
        });

        builder.ConfigureServices(service =>
        {
            service.AddWebApi(Configuration);
        });
    }
}
