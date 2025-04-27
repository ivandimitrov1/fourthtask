using Fourth.Api.Responses;
using Fourth.Domain.Models;

namespace Fourth.Api.Mapping;

public static class CustomerRestMapper
{
    public static CustomerNameResponse MapToCustomerName(this CustomerDomain domain)
    {
        if (domain == null)
        {
            return null;
        }

        return new CustomerNameResponse
        {
            CustomerId = domain.CustomerId,
            ContactName = domain.ContactName
        };
    }

    public static CustomerResponse MapToRest(this CustomerDomain domain)
    {
        if (domain == null)
        {
            return null;
        }

        return new CustomerResponse
        {
            CustomerId = domain.CustomerId,
            CompanyName = domain.CompanyName,
            ContactName = domain.ContactName,
            ContactTitle = domain.ContactTitle,
            Address = domain.Address,
            City = domain.City,
            Region = domain.Region,
            PostalCode = domain.PostalCode,
            Country = domain.Country,
            Phone = domain.Phone,
            Fax = domain.Fax
        };
    }
}