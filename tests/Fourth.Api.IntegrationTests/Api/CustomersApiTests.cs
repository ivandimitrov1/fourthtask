using Fourth.Infrastructure.Data;
using Fourth.IntegrationTests;
using Refit;

namespace Fourth.Api.IntegrationTests.Controllers;

[Collection(nameof(ApiWebApplicationFactory))]
public class CustomersApiTests
{
	private readonly HttpClient _client;
	private readonly ICustomersApiContract _customerApi;
	private readonly FourthContext _dbContext;
	public CustomersApiTests(ApiWebApplicationFactory factory)
	{
		_client = factory.CreateClient();
		_customerApi = RestService.For<ICustomersApiContract>(_client);
	}

	[Fact]
	public async Task GetCustomers_should_return_list_of_customers()
	{
		// Act
		var response = await _customerApi.GetCustomers();

		// Assert
		Assert.True(response.Success);
		Assert.NotEmpty(response.Data);

		var customer = response.Data.FirstOrDefault(x => x.CustomerId == "ALFKI");
		Assert.NotNull(customer);
	}
}
