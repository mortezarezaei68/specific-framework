using Framework.Exception.Exceptions.Enum;

namespace Framework.Exception.Exceptions
{
    /// <summary>
    /// Exception for bad input
    /// </summary>
    public class BadRequestException : BaseException
    {
        /// <summary>
        /// Exception for bad input
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        public BadRequestException(string message, ResultCode? code = null) : base(message, code: code)
        {

        }
    }
}
