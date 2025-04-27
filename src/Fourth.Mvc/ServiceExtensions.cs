using Fourth.Mvc.Options;
using Microsoft.Extensions.Configuration;

namespace Fourth.Mvc;

public static class ServiceExtensions
{
    public static void AddMvcServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<WebApiOptions>(configuration.GetSection(WebApiOptions.Section));
    }
}
