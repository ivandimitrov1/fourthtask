using Fourth.Api.Responses;
using Fourth.Domain.Models;

namespace Fourth.Api.Mapping;

public static class OrderRestMapper
{
    private const string IssuesWithTheOrderText = "Order might not be executed.";

    public static IList<OrderResponse> MapToRest(this IList<OrderDomain> domains)
    {
        if (domains == null)
        {
            return null;
        }

        return domains.Select(MapToRest).ToList();
    }

    public static OrderResponse MapToRest(this OrderDomain domain)
    {
        if (domain == null)
        {
            return null;
        }

        var response = new OrderResponse
        {
            OrderId = domain.OrderId,
            CustomerId = domain.CustomerId,
            EmployeeId = domain.EmployeeId,
            OrderDate = domain.OrderDate,
        };

        // TO:DO
        // add localizations
        response.Information = domain.HasIssuesWithOrder() ? IssuesWithTheOrderText : null;
        response.Total = domain.GetTotal();

        return response;
    }
}
