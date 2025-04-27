using Fourth.Domain.Models;

namespace Fourth.Application.Services.Interfaces;

public interface ICustomerService
{
    public Task<IList<CustomerDomain>> GetCustomersAsync();

    public Task<CustomerDomain?> GetCustomerByIdAsync(string customerId);

    public Task<IList<OrderDomain>> GetCustomerOrdersByIdAsync(string customerId);
}
