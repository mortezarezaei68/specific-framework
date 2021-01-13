﻿using System;

namespace Common.Exceptions
{
    public class LogicException : AppException
    {
        public LogicException() 
            : base(ApiResultCode.LogicError)
        {
        }

        public LogicException(string message) 
            : base(ApiResultCode.LogicError, message)
        {
        }

        public LogicException(object additionalData) 
            : base(ApiResultCode.LogicError, additionalData)
        {
        }

        public LogicException(string message, object additionalData) 
            : base(ApiResultCode.LogicError, message, additionalData)
        {
        }

        public LogicException(string message, Exception exception)
            : base(ApiResultCode.LogicError, message, exception)
        {
        }

        public LogicException(string message, Exception exception, object additionalData)
            : base(ApiResultCode.LogicError, message, exception, additionalData)
        {
        }
    }
}
