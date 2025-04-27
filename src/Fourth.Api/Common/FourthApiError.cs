using System.Net;

namespace Fourth.Api.Utils;

public class FourthApiError
{
    public FourthApiError(string code, string message, HttpStatusCode httpStatusCode)
    {
        Code = code;
        Message = message;
        HttpStatusCode = httpStatusCode;
    }

    public string Code { get; set; }
    public string Message { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }
}
