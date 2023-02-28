using Framework.Exception.Exceptions.Enum;

namespace Framework.Exception.Exceptions
{
    /// <summary>
    /// Conflicts are most likely to occur in response to a PUT request when current data exists in the database
    /// </summary>
    public class ConflictException : BaseException
    {
        /// <summary>
        /// Conflicts are most likely to occur in response to a PUT request when current data exists in the database
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        public ConflictException(string message, ResultCode? code = null) : base(message, code: code)
        {
        }
    }
}
