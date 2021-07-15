using System;
using System.Linq;
using Common;
using Common.Utilities;
using Framework.Exception.DataAccessConfig;
using Framework.Exception.Exceptions.Enum;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Framework.Commands.CommandHandlers
{
    public class ResponseCommand
    {
        public ResponseCommand( bool isSuccess, ResultCode resultCode, string message=null)
        {
            Message = message ?? EnumExtensions.ToDisplay(resultCode);
            IsSuccess = isSuccess;
            ResultCode = resultCode;
        }
        public bool IsSuccess { get; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get;  }
        
        public ResultCode ResultCode { get; }
        
        #region Implicit Operators
        public static implicit operator ResponseCommand(OkResult result)=> new(true, ResultCode.Success);
        public static implicit operator ResponseCommand(BadRequestResult result) => new(false, ResultCode.BadRequest);
        public static implicit operator ResponseCommand(BadRequestObjectResult result)
        {
            var message = result.Value.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            return new ResponseCommand(false, ResultCode.BadRequest, message);
        }

        public static implicit operator ResponseCommand(ContentResult result) => new(true, ResultCode.Success, result.Content);
        public static implicit operator ResponseCommand(NotFoundResult result)=> new(false, ResultCode.NotFound);
        // public static implicit operator ResponseCommand(CudResult data)
        // {
        //     switch (data.Status)
        //     {
        //         case CudResultStatus.Success:
        //             return new ResponseCommand(true, ResultCode.Success);
        //         case CudResultStatus.Duplicate:
        //             return new ResponseCommand(false, ResultCode.Duplicate);
        //         case CudResultStatus.ValidationError:
        //             return new ResponseCommand(false, ResultCode.LogicError);
        //         case CudResultStatus.GeneralException:
        //             return new ResponseCommand(false, ResultCode.ServerError);
        //         case CudResultStatus.ForiegnKeyException:
        //             return new ResponseCommand(false, ResultCode.ForeignKeyException);
        //         case CudResultStatus.NotFound:
        //             return new ResponseCommand(false, ResultCode.NotFound);
        //         default:
        //             throw new ArgumentOutOfRangeException();
        //     }
        // }

        #endregion
    }

    public class ResponseCommand<TResult> : ResponseCommand where TResult:class
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TResult Data { get;  }

        public ResponseCommand(bool isSuccess, ResultCode resultCode, TResult data, string message = null) : base(isSuccess, resultCode, message)
        {
            Data = data;
        }
        
        // public static ApiResult<ResponseCommand<TData>> FromDataReadResult(ResponseCommand<TData> result)
        // {
        //     switch (result.ResultCode)
        //     {
        //         case ResultStatus.Success:
        //             return new ApiResult<ResponseCommand<TData>>(true, ResultCode.Success, result);
        //         case ResultStatus.NotFound:
        //             return new ApiResult<ResponseCommand<TData>>(true, ResultCode.Success, result);
        //         case ResultStatus.ListEmpty:
        //             return new ApiResult<ResponseCommand<TData>>(true, ResultCode.Success, result);
        //         case ResultStatus.UnAuthorized:
        //             return new ApiResult<ResponseCommand<TData>>(false, ResultCode.Success, result);
        //         case ResultStatus.GeneralException:
        //             return new ApiResult<ResponseCommand<TData>>(false, ResultCode.Success, result);
        //         default:
        //             throw new ArgumentOutOfRangeException();
        //     }
        // }

        // public static ApiResult<ResponseCommand> FromDataReadCollectionResult(ResponseCommand result)
        // {
        //     switch (result.ResultCode)
        //     {
        //         case ResultStatus.Success:
        //             return new ApiResult<ResponseCommand>(true, ResultCode.Success, result);
        //         case ResultStatus.NotFound:
        //             return new ApiResult<ResponseCommand>(true, ResultCode.Success, result);
        //         case ResultStatus.ListEmpty:
        //             return new ApiResult<ResponseCommand>(true, ResultCode.Success, result);
        //         case ResultStatus.UnAuthorized:
        //             return new ApiResult<ResponseCommand>(false, ResultCode.Success, result);
        //         case ResultStatus.GeneralException:
        //             return new ApiResult<ResponseCommand>(false, ResultCode.Success, result);
        //         default:
        //             throw new ArgumentOutOfRangeException();
        //     }
        // }

        #region Implicit Operators

        public static implicit operator ResponseCommand<TResult>(OkResult result)
        {
            return new (true, ResultCode.Success, null);
        }

        public static implicit operator ResponseCommand<TResult>(OkObjectResult result)
        {
            return new (true, ResultCode.Success, (TResult)result.Value);
        }

        public static implicit operator ResponseCommand<TResult>(BadRequestResult result)
        {
            return new (false, ResultCode.BadRequest, null);
        }

        public static implicit operator ResponseCommand<TResult>(BadRequestObjectResult result)
        {
            var message = result.Value.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            return new (false, ResultCode.BadRequest, null, message);
        }

        public static implicit operator ResponseCommand<TResult>(ContentResult result)
        {
            return new (true, ResultCode.Success, null, result.Content);
        }

        public static implicit operator ResponseCommand<TResult>(NotFoundResult result)
        {
            return new (false, ResultCode.NotFound, null);
        }

        public static implicit operator ResponseCommand<TResult>(NotFoundObjectResult result)
        {
            return new (false, ResultCode.NotFound, (TResult)result.Value);
        }

        #endregion
    }
}