﻿using System;

namespace Common.Exceptions
{
    public class NotFoundException : AppException
    {
        public NotFoundException()
            : base(ApiResultCode.NotFound)
        {
        }

        public NotFoundException(string message)
            : base(ApiResultCode.NotFound, message)
        {
        }

        public NotFoundException(object additionalData)
            : base(ApiResultCode.NotFound, additionalData)
        {
        }

        public NotFoundException(string message, object additionalData)
            : base(ApiResultCode.NotFound, message, additionalData)
        {
        }

        public NotFoundException(string message, Exception exception)
            : base(ApiResultCode.NotFound, message, exception)
        {
        }

        public NotFoundException(string message, Exception exception, object additionalData)
            : base(ApiResultCode.NotFound, message, exception, additionalData)
        {
        }
    }
}
