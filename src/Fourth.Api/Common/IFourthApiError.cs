using Fourth.Api.Utils;

namespace Fourth.Api.Common;

public interface IFourthApiError<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public FourthApiError Error { get; set; }
}
