using Fourth.Domain.Models;
using Fourth.Infrastructure.Data.Entities;

namespace Fourth.Infrastructure.Data.Mapping;

public static class OrderEntityMapper
{
    public static OrderDomain MapToDomain(this Order entity)
    {
        if (entity == null)
        {
            return null;
        }

        var domain =  new OrderDomain
        {
            OrderId = entity.OrderId,
            CustomerId = entity.CustomerId,
            EmployeeId = entity.EmployeeId,
            OrderDate = entity.OrderDate,
            Details = entity.OrderDetails.Select(x => new OrderDetailDomain
            {
                UnitPrice = x.UnitPrice,
                Quantity = x.Quantity,
                Product = new ProductDomain
                {
                    Id = x.ProductId,
                    UnitsInStock = x.Product.UnitsInStock,
                    UnitsOnOrder = x.Product.UnitsOnOrder,
                    Discontinued = x.Product.Discontinued,
                }

            }).ToList(),
        };

        return domain;
    }
}
