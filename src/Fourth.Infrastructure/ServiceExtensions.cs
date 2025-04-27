using Fourth.Application.Ports;
using Fourth.Infrastructure.Data;
using Fourth.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fourth.Infrastructure;

public static class ServiceExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddDbContext<FourthContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));
    }
}