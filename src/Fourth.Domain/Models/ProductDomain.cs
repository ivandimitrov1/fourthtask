namespace Fourth.Domain.Models;

// TO:DO 
// set private setters and introduec update methods once it is needed
public class ProductDomain
{
    public int Id { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public bool Discontinued { get; set; }
}
