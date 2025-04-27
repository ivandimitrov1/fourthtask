using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Fourth.Application.Services.Interfaces;
using Fourth.Application.Services;

namespace Fourth.Application;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICustomerService, CustomerService>();
    }
}