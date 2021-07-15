using System;
using System.Collections.Generic;

namespace Framework.Queries
{
    public class BaseResponseQuery
    {
        public BaseResponseQuery(bool isSuccess,string message=null)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
    }

    public class ResponseQuery<TResult> : BaseResponseQuery where TResult:class
    {
        public ResponseQuery(bool isSuccess, TResult data, int count=1,  string message = null) : base(isSuccess, message)
        {
            Data = data;
            Count = count;
        }
        public TResult Data { get; private set; }
        public int Count { get; private set; }
    }
    public class ResponseIdQuery : BaseResponseQuery 
    {

        public int Id { get; private set; }

        public ResponseIdQuery(bool isSuccess, int id, string message = null) : base(isSuccess, message)
        {
            Id = id;
        }
    }
}