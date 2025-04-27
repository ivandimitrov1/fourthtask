using Fourth.Application.Ports;
using Fourth.Domain.Models;
using Fourth.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Fourth.Infrastructure.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly FourthContext _dbContext;

    public OrderRepository(FourthContext context)
    {
        _dbContext = context;
    }

    public async Task<IList<OrderDomain>> GetOrdersByCustomerId(string customerId)
    {
        // TO:DO
        // see if it can be optimized
        // maybe we can load the products afterwards to remove the duplication
        return (await _dbContext
            .Orders
            .Where(order => order.CustomerId == customerId)
            .Include(order => order.OrderDetails).ThenInclude(details => details.Product)
            .ToListAsync())
            .Select(OrderEntityMapper.MapToDomain)
            .ToList();
    }
}