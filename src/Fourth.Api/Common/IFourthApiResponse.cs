namespace Fourth.Api.Utils;

public interface IFourthApiResponse<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
}
