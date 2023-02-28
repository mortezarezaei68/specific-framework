using Framework.Exception.Exceptions.Enum;

namespace Framework.Exception.Exceptions
{
    /// <summary>
    /// Exception for when a resource is not found
    /// </summary>
    public class NotFoundException : BaseException
    {
        /// <summary>
        /// Exception for when a resource is not found
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        public NotFoundException(string message, ResultCode? code = null) : base(message, code: code)
        {
        }
    }
}
