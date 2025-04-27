using Fourth.Api.Utils;

namespace Fourth.Api.Common;

public static class FourthApiErrors
{
    public static FourthApiError CustomerNotFoundError = new FourthApiError("100", "Customer is not found.", System.Net.HttpStatusCode.NotFound);
}
