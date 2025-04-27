using Fourth.Api.Responses;
using Fourth.Api.Utils;
using Refit;

namespace Fourth.Api.IntegrationTests;

public interface ICustomersApiContract
{
	[Get("/api/customers")]
	public Task<FourthApiResponse<IList<CustomerNameResponse>>> GetCustomers();

	[Get("/api/customers/{id}")]
	public Task<FourthApiResponse<IList<CustomerNameResponse>>> GetCustomer(string id);

	[Get("/api/customers/{id}/orders")]
	public Task<FourthApiResponse<IList<CustomerNameResponse>>> GetCustomerOrders(string id);
}
