﻿using System;

namespace Common.Exceptions
{
    public class BadRequestException : AppException
    {
        public BadRequestException()
            : base(ApiResultCode.BadRequest)
        {
        }

        public BadRequestException(string message)
            : base(ApiResultCode.BadRequest, message)
        {
        }

        public BadRequestException(object additionalData)
            : base(ApiResultCode.BadRequest, additionalData)
        {
        }

        public BadRequestException(string message, object additionalData)
            : base(ApiResultCode.BadRequest, message, additionalData)
        {
        }

        public BadRequestException(string message, Exception exception)
            : base(ApiResultCode.BadRequest, message, exception)
        {
        }

        public BadRequestException(string message, Exception exception, object additionalData)
            : base(ApiResultCode.BadRequest, message, exception, additionalData)
        {
        }
    }
}
