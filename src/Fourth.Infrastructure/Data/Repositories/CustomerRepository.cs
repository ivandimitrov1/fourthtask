using Fourth.Application.Ports;
using Fourth.Domain.Models;
using Fourth.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Fourth.Infrastructure.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly FourthContext _dbContext;
    public CustomerRepository(FourthContext context)
    {
        _dbContext = context;
    }

    public async Task<IList<CustomerDomain>> GetCustomersAsync()
    {
        return (await _dbContext.Customers.ToListAsync())
            .Select(CutomerEntityMapper.MapToDomain)
            .ToList();
    }

    public async Task<CustomerDomain?> GetCustomerByIdAsync(string customerId)
    {
        var entity = await _dbContext.Customers.FindAsync(customerId);
        return CutomerEntityMapper.MapToDomain(entity);
    }
}
