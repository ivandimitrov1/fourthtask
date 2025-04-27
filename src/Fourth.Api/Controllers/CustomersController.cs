using Fourth.Api.Common;
using Fourth.Api.Mapping;
using Fourth.Api.Responses;
using Fourth.Api.Utils;
using Fourth.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fourth.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ILogger<CustomersController> _logger;
    private readonly ICustomerService _customerService;

    public CustomersController(
        ILogger<CustomersController> logger,
        ICustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }

    [HttpGet]
    [ProducesResponseType<IFourthApiResponse<CustomerNameResponse>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = (await _customerService.GetCustomersAsync())
            .Select(CustomerRestMapper.MapToCustomerName)
            .ToList();

        return Ok(FourthApiResponse<IList<CustomerNameResponse>>.SuccessResponse(customers));
    }

    [HttpGet("{id}")]
    [ProducesResponseType<IFourthApiError<CustomerResponse>>(StatusCodes.Status404NotFound)]
    [ProducesResponseType<IFourthApiResponse<CustomerResponse>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCustomer(string id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);

        if (customer is null) 
        {
            var error = FourthApiResponse<CustomerResponse>.ErrorResponse(FourthApiErrors.CustomerNotFoundError);
            return NotFound(error);
        }

        return Ok(FourthApiResponse<CustomerResponse>.SuccessResponse(CustomerRestMapper.MapToRest(customer)));
    }

    [HttpGet("{id}/orders")]
    [ProducesResponseType<IFourthApiError<CustomerResponse>>(StatusCodes.Status404NotFound)]
    [ProducesResponseType<IFourthApiResponse<OrderResponse>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCustomerOrders(string id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);

        if (customer is null)
        {
            var error = FourthApiResponse<CustomerResponse>.ErrorResponse(FourthApiErrors.CustomerNotFoundError);
            return NotFound(error);
        }

        var orders = await _customerService.GetCustomerOrdersByIdAsync(customer.CustomerId);
        return Ok(FourthApiResponse<IList<OrderResponse>>.SuccessResponse(OrderRestMapper.MapToRest(orders)));
    }
}