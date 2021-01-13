﻿using System;
using System.Net;

namespace Common.Exceptions
{
    public class AppException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public ApiResultCode ApiResultCode { get; set; }
        public object AdditionalData { get; set; }

        public AppException()
            : this(ApiResultCode.ServerError)
        {
        }

        public AppException(ApiResultCode apiResultCode)
            : this(apiResultCode, null)
        {
        }

        public AppException(string message)
            : this(ApiResultCode.ServerError, message)
        {
        }

        public AppException(ApiResultCode apiResultCode, string message)
            : this(apiResultCode, message, HttpStatusCode.InternalServerError)
        {
        }

        public AppException(string message, object additionalData)
            : this(ApiResultCode.ServerError, message, additionalData)
        {
        }

        public AppException(ApiResultCode apiResultCode, object additionalData)
            : this(apiResultCode, null, additionalData)
        {
        }

        public AppException(ApiResultCode apiResultCode, string message, object additionalData)
            : this(apiResultCode, message, HttpStatusCode.InternalServerError, additionalData)
        {
        }

        public AppException(ApiResultCode apiResultCode, string message, HttpStatusCode httpStatusCode)
            : this(apiResultCode, message, httpStatusCode, null)
        {
        }

        public AppException(ApiResultCode apiResultCode, string message, HttpStatusCode httpStatusCode, object additionalData)
            : this(apiResultCode, message, httpStatusCode, null, additionalData)
        {
        }

        public AppException(string message, Exception exception)
            : this(ApiResultCode.ServerError, message, exception)
        {
        }

        public AppException(string message, Exception exception, object additionalData)
            : this(ApiResultCode.ServerError, message, exception, additionalData)
        {
        }

        public AppException(ApiResultCode apiResultCode, string message, Exception exception)
            : this(apiResultCode, message, HttpStatusCode.InternalServerError, exception)
        {
        }

        public AppException(ApiResultCode apiResultCode, string message, Exception exception, object additionalData)
            : this(apiResultCode, message, HttpStatusCode.InternalServerError, exception, additionalData)
        {
        }

        public AppException(ApiResultCode apiResultCode, string message, HttpStatusCode httpStatusCode, Exception exception)
            : this(apiResultCode, message, httpStatusCode, exception, null)
        {
        }

        public AppException(ApiResultCode apiResultCode, string message, HttpStatusCode httpStatusCode, Exception exception, object additionalData)
            : base(message, exception)
        {
            ApiResultCode = apiResultCode;
            HttpStatusCode = httpStatusCode;
            AdditionalData = additionalData;
        }
    }
}
