using Framework.Exception.Exceptions.Enum;

namespace Framework.Exception.Exceptions
{
    /// <summary>
    /// Exception thrown when a method is called with an invalid parameter
    /// </summary>
    public class ValidationException : BaseException
    {
        /// <summary>
        /// Exception thrown when a method is called with an invalid parameter
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        public ValidationException(string message, ResultCode? code = null) : base(message, code: code)
        {
        }
    }
}
