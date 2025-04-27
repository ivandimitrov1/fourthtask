using Fourth.Domain.Models;

namespace Fourth.Application.Ports;

public interface ICustomerRepository
{
    // TO:DO add pagination
    public Task<IList<CustomerDomain>> GetCustomersAsync();

    public Task<CustomerDomain?> GetCustomerByIdAsync(string customerId);
}
