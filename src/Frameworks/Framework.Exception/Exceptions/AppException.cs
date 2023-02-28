using System.Net;
using Framework.Exception.Exceptions.Enum;

namespace Framework.Exception.Exceptions;

/// <summary>
/// Exception for application layer
/// </summary>
public class AppException : BaseException
{
    /// <summary>
    /// Exception for application layer
    /// </summary>
    /// <param name="message"></param>
    /// <param name="code"></param>
    public AppException(string message, ResultCode? code = null) : base(message, code: code)
    {
    }

    /// <summary>
    /// Exception for application layer
    /// </summary>
    public AppException() : base()
    {
    }

    /// <summary>
    /// Exception for application layer
    /// </summary>
    /// <param name="message"></param>
    /// <param name="statusCode"></param>
    /// <param name="code"></param>
    public AppException(string message, HttpStatusCode statusCode, ResultCode? code = null) : base(message, statusCode, code)
    {
    }

    /// <summary>
    /// Exception for application layer
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    /// <param name="code"></param>
    public AppException(string message,  System.Exception innerException, ResultCode? code = null) : base(message, innerException, code: code)
    {
    }
}
