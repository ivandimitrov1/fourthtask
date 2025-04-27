using Fourth.Domain.Models;

namespace Fourth.Application.Ports;

public interface IOrderRepository
{
    public Task<IList<OrderDomain>> GetOrdersByCustomerId(string customerId);
}
