using System.Globalization;
using System.Net;
using Framework.Exception.Exceptions.Enum;

namespace Framework.Exception.Exceptions
{
    /// <summary>
    /// Exception for when a request is made to a server that is not available
    /// </summary>
    public class InternalServerException : BaseException
    {
        /// <summary>
        /// Exception for when a request is made to a server that is not available
        /// </summary>
        public InternalServerException() : base() { }

        /// <summary>
        /// Exception for when a request is made to a server that is not available
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        public InternalServerException(string message, ResultCode? code) : base(message, HttpStatusCode.InternalServerError, code: code) { }

        /// <summary>
        /// Exception for when a request is made to a server that is not available
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        /// <param name="args"></param>
        public InternalServerException(string message, ResultCode? code = null, params object[] args)
            : base(message:String.Format(CultureInfo.CurrentCulture, message, args, HttpStatusCode.InternalServerError, code))
        {
        }
    }
}
