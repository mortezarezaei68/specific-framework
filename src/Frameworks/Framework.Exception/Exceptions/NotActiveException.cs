using System.Net;
using Common.Exceptions;
using Framework.Exception.Exceptions.Enum;

namespace Framework.Exception.Exceptions
{
    public class NotActiveException:AppException
    {
        public NotActiveException()
            : base(ResultCode.NotActive)
        {
        }
        public NotActiveException(string message)
            : base(ResultCode.NotActive, message)
        {
        }

        public NotActiveException(object additionalData)
            : base(ResultCode.NotActive, additionalData)
        {
        }

        public NotActiveException(string message, object additionalData)
            : base(ResultCode.NotActive, message, additionalData)
        {
        }

        public NotActiveException(string message, System.Exception exception)
            : base(ResultCode.NotActive, message, exception)
        {
        }

        public NotActiveException(string message, System.Exception exception, object additionalData)
            : base(ResultCode.NotActive, message, exception, additionalData)
        {
        }
        public NotActiveException(ResultCode resultCode, string message, HttpStatusCode httpStatusCode, System.Exception exception, object additionalData)
            : base( resultCode,  message,  httpStatusCode,  exception,  additionalData)
        {
            ResultCode = resultCode;
            HttpStatusCode = httpStatusCode;
            AdditionalData = additionalData;
        }
    }
}