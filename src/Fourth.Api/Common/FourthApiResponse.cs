using Fourth.Api.Common;

namespace Fourth.Api.Utils;

public class FourthApiResponse<T> : IFourthApiResponse<T>, IFourthApiError<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public FourthApiError? Error { get; set; }

    public FourthApiResponse(bool success, T data, FourthApiError error)
    {
        Success = success;
        Data = data;
        Error = error;
    }

    public static FourthApiResponse<T> SuccessResponse(T data)
    {
        return new FourthApiResponse<T>(true, data, null);
    }

    public static FourthApiResponse<T> ErrorResponse(FourthApiError error)
    {
        return new FourthApiResponse<T>(false, default(T), error);
    }
}
