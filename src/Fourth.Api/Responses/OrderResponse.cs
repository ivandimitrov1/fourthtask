namespace Fourth.Api.Responses;

public class OrderResponse
{
    public int OrderId { get; set; }

    public string? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? Total {  get; set; }

    public string Information { get; set; }
}
