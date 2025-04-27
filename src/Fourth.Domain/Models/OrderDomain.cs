namespace Fourth.Domain.Models;

// TO:DO 
// set private setters and introduec update methods once it is needed
public class OrderDomain
{
    public int OrderId { get; set; }

    public string? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public IList<OrderDetailDomain> Details { get; set; } = new List<OrderDetailDomain>();

    public bool HasIssuesWithOrder()
    {
        return Details.Any(orderDetail => orderDetail.Product.Discontinued 
                    || (orderDetail.Product.UnitsInStock < orderDetail.Product.UnitsOnOrder));
    }

    public decimal GetTotal()
    {
        return Details.Select(orderDetail => orderDetail.UnitPrice * orderDetail.Quantity).Sum();
    }
}
