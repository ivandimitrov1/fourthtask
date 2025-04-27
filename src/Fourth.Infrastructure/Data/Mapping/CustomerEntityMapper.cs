using Fourth.Domain.Models;
using Fourth.Infrastructure.Data.Entities;

namespace Fourth.Infrastructure.Data.Mapping;

public static class CutomerEntityMapper
{
    public static CustomerDomain MapToDomain(this Customer? entity)
    {
        if (entity == null)
        {
            return null;
        }

        return new CustomerDomain
        {
            CustomerId = entity.CustomerId,
            CompanyName = entity.CompanyName,
            ContactName = entity.ContactName,
            ContactTitle = entity.ContactTitle,
            Address = entity.Address,
            City = entity.City,
            Region = entity.Region,
            PostalCode = entity.PostalCode,
            Country = entity.Country,
            Phone = entity.Phone,
            Fax = entity.Fax
        };
    }
}
