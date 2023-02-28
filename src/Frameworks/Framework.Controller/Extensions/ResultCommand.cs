using Common.Utilities;
using Framework.Exception.DataAccessConfig;
using Framework.Exception.Exceptions.Enum;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DisplayProperty = Common.Utilities.DisplayProperty;

namespace Framework.Controller.Extensions
{
    public class ResultCommand
    {
        public ResultCommand(bool isSuccess, ResultCode resultCode)
        {
            IsSuccess = isSuccess;
            ResultCode = resultCode;
        }

        public ResultCommand(bool isSuccess, ResultCode resultCode, string? message = null)
        {
            Message = message ?? EnumExtensions.ToDisplay(resultCode);
            IsSuccess = isSuccess;
            ResultCode = resultCode;
        }

        public ResultCommand(bool isSuccess, ResultCode resultCode, object? data)
        {
            IsSuccess = isSuccess;
            ResultCode = resultCode;
            Data = data;
        }

        public ResultCommand(bool isSuccess, ResultCode resultCode, object? data = null, string? message = null)
        {
            Message = message ?? EnumExtensions.ToDisplay(resultCode);
            IsSuccess = isSuccess;
            ResultCode = resultCode;
            Data = data;
        }

        public bool IsSuccess { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object? Data { get; }

        public ResultCode ResultCode { get; }

        #region Implicit Operators

        public static implicit operator ResultCommand(OkResult result) => new(true, ResultCode.Success);
        public static implicit operator ResultCommand(BadRequestResult result) => new(false, ResultCode.BadRequest);

        public static implicit operator ResultCommand(BadRequestObjectResult result)
        {
            var message = result.Value.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[]) p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }

            return new ResultCommand(false, ResultCode.BadRequest, message);
        }

        public static implicit operator ResultCommand(OkObjectResult result)
        {
            ResultCommand resultCommand;
            resultCommand = result.Value as ResponseCommand;
            return resultCommand;
        }

        public static implicit operator ResultCommand(ContentResult result) =>
            new(true, ResultCode.Success, result.Content);

        public static implicit operator ResultCommand(NotFoundResult result) => new(false, ResultCode.NotFound);

        public static implicit operator ResultCommand(ResponseCommand? data)
        {
            return data.Status switch
            {
                ResultStatus.Success => new ResultCommand(true, ResultCode.Success,
                    data.Data),
                ResultStatus.Duplicate => new ResultCommand(true, ResultCode.Duplicate,
                    ResultCode.Duplicate.ToDisplay(DisplayProperty.Name)),
                ResultStatus.NotFound => new ResultCommand(true, ResultCode.NotFound,
                    ResultCode.NotFound.ToDisplay(DisplayProperty.Name)),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        #endregion
    }
}