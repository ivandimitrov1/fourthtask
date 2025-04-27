using Fourth.Application.Ports;
using Fourth.Application.Services.Interfaces;
using Fourth.Domain.Models;

namespace Fourth.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IOrderRepository _orderRepository;
    public CustomerService(
        ICustomerRepository customerRepository,
        IOrderRepository orderRepository)
    {
        _customerRepository = customerRepository;
        _orderRepository = orderRepository;
    }

    public async Task<IList<CustomerDomain>> GetCustomersAsync()
    {
        return await _customerRepository.GetCustomersAsync();
    }

    public async Task<CustomerDomain?> GetCustomerByIdAsync(string customerId)
    {
        return await _customerRepository.GetCustomerByIdAsync(customerId);
    }

    public async Task<IList<OrderDomain>> GetCustomerOrdersByIdAsync(string customerId)
    {
        return await _orderRepository.GetOrdersByCustomerId(customerId);
    }
}
