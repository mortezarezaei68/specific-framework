using System.Text.Json.Serialization;
using Framework.Exception.Exceptions.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Framework.Exception.Exceptions;

/// <summary>
/// Base format for all error responses with problem details
/// </summary>
internal class ProblemDetailsWithCode : ProblemDetails
{
    [JsonPropertyName("code")]
    public ResultCode? Code { get; set; }
}
