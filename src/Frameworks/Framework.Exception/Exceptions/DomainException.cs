using System.Net;
using Framework.Exception.Exceptions.Enum;

namespace Framework.Exception.Exceptions;

/// <summary>
/// Exception for domain layer
/// </summary>
public class DomainException : BaseException
{
    /// <summary>
    /// Exception for domain layer
    /// </summary>
    /// <param name="message"></param>
    /// <param name="code"></param>
    public DomainException(string message, ResultCode? code = null) : base(message, code: code)
    {
    }

    /// <summary>
    /// Exception for domain layer
    /// </summary>
    public DomainException() : base()
    {
    }

    /// <summary>
    /// Exception for domain layer
    /// </summary>
    /// <param name="message"></param>
    /// <param name="statusCode"></param>
    /// <param name="code"></param>
    public DomainException(string message, HttpStatusCode statusCode, ResultCode? code = null) : base(message, statusCode, code)
    {
    }

    
    /// <summary>
    /// Exception for domain layer
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    /// <param name="code"></param>
    public DomainException(string message,  System.Exception innerException, ResultCode? code = null) : base(message, innerException, code: code)
    {
    }
}
