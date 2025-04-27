namespace Fourth.Domain.Models;

// TO:DO 
// set private setters and introduec update methods once it is needed
public class OrderDetailDomain
{
    public decimal UnitPrice { get; set; }

    public short Quantity { get; set; }

    public ProductDomain Product { get; set; }
}
