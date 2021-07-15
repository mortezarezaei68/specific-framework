﻿using System;
using System.Net;
 using Framework.Exception.Exceptions.Enum;

 namespace Common.Exceptions
{
    public class AppException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public ResultCode ResultCode { get; set; }
        public object AdditionalData { get; set; }

        public AppException()
            : this(ResultCode.ServerError)
        {
        }

        public AppException(ResultCode resultCode)
            : this(resultCode, null)
        {
        }

        public AppException(string message)
            : this(ResultCode.ServerError, message)
        {
        }

        public AppException(ResultCode resultCode, string message)
            : this(resultCode, message, HttpStatusCode.InternalServerError)
        {
        }

        public AppException(string message, object additionalData)
            : this(ResultCode.ServerError, message, additionalData)
        {
        }

        public AppException(ResultCode resultCode, object additionalData)
            : this(resultCode, null, additionalData)
        {
        }

        public AppException(ResultCode resultCode, string message, object additionalData)
            : this(resultCode, message, HttpStatusCode.InternalServerError, additionalData)
        {
        }

        public AppException(ResultCode resultCode, string message, HttpStatusCode httpStatusCode)
            : this(resultCode, message, httpStatusCode, null)
        {
        }

        public AppException(ResultCode resultCode, string message, HttpStatusCode httpStatusCode, object additionalData)
            : this(resultCode, message, httpStatusCode, null, additionalData)
        {
        }

        public AppException(string message, Exception exception)
            : this(ResultCode.ServerError, message, exception)
        {
        }

        public AppException(string message, Exception exception, object additionalData)
            : this(ResultCode.ServerError, message, exception, additionalData)
        {
        }

        public AppException(ResultCode resultCode, string message, Exception exception)
            : this(resultCode, message, HttpStatusCode.InternalServerError, exception)
        {
        }

        public AppException(ResultCode resultCode, string message, Exception exception, object additionalData)
            : this(resultCode, message, HttpStatusCode.InternalServerError, exception, additionalData)
        {
        }

        public AppException(ResultCode resultCode, string message, HttpStatusCode httpStatusCode, Exception exception)
            : this(resultCode, message, httpStatusCode, exception, null)
        {
        }

        public AppException(ResultCode resultCode, string message, HttpStatusCode httpStatusCode, Exception exception, object additionalData)
            : base(message, exception)
        {
            ResultCode = resultCode;
            HttpStatusCode = httpStatusCode;
            AdditionalData = additionalData;
        }
    }
}
