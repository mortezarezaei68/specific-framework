﻿using System;
 using Framework.Exception.Exceptions.Enum;

 namespace Common.Exceptions
{
    public class LogicException : AppException
    {
        public LogicException() 
            : base(ResultCode.LogicError)
        {
        }

        public LogicException(string message) 
            : base(ResultCode.LogicError, message)
        {
        }

        public LogicException(object additionalData) 
            : base(ResultCode.LogicError, additionalData)
        {
        }

        public LogicException(string message, object additionalData) 
            : base(ResultCode.LogicError, message, additionalData)
        {
        }

        public LogicException(string message, Exception exception)
            : base(ResultCode.LogicError, message, exception)
        {
        }

        public LogicException(string message, Exception exception, object additionalData)
            : base(ResultCode.LogicError, message, exception, additionalData)
        {
        }
    }
}
