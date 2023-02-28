using System.Net;
using Framework.Exception.Exceptions.Enum;

namespace Framework.Exception.Exceptions;

/// <summary>
/// Base class for all exceptions thrown by problem details
/// </summary>
public class BaseException : System.Exception
{
    /// <summary>
    /// Base class for all exceptions thrown by problem details
    /// </summary>
    /// <param name="message"></param>
    /// <param name="statusCode"></param>
    /// <param name="code"></param>
    public BaseException(
        string message,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        ResultCode? code = null) : base(message)
    {
        StatusCode = statusCode;
        Code = code;
    }

    /// <summary>
    /// Base class for all exceptions thrown by problem details
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    /// <param name="statusCode"></param>
    /// <param name="code"></param>
    public BaseException(
        string message,
        System.Exception innerException,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        ResultCode? code = null) : base(message, innerException)
    {
        StatusCode = statusCode;
        Code = code;
    }

    /// <summary>
    /// Base class for all exceptions thrown by problem details
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="code"></param>
    public BaseException(
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        ResultCode? code = null) : base()
    {
        StatusCode = statusCode;
        Code = code;
    }

    public HttpStatusCode StatusCode { get; }

    public ResultCode? Code { get; }
}
