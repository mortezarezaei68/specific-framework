using System.Linq;
using Common;
using Framework.Infra.ManualCommandHandlers.CommandHandlers;
using Framework.Exception.Exceptions.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Framework.Controller.Extensions
{
 public class ApiResultFilterAttribute : ActionFilterAttribute
    {               
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            ResultCommand resultCommand;
            switch (context.Result)
            {
                case OkObjectResult okObjectResult:
                    // var apiResult = new ApiResult<object>(true, ApiResultCode.Success, okObjectResult.Value);
                    resultCommand = okObjectResult;
                    context.Result = new JsonResult(resultCommand) { StatusCode = okObjectResult.StatusCode };
                    break;
                case OkResult okResult:
                {
                    resultCommand = okResult;
                    context.Result = new JsonResult(resultCommand) { StatusCode = okResult.StatusCode };
                    break;
                }
                //return BadRequest() method create an ObjectResult with StatusCode 400 in recent versions, So the following code has changed a bit.
                case ObjectResult badRequestObjectResult when badRequestObjectResult.StatusCode == 400:
                {
                    string message = null;
                    switch (badRequestObjectResult.Value)
                    {
                        case ValidationProblemDetails validationProblemDetails:
                            var errorMessages = validationProblemDetails.Errors.SelectMany(p => p.Value).Distinct();
                            message = string.Join(" | ", errorMessages);
                            break;
                        case SerializableError errors:
                            var errorMessages2 = errors.SelectMany(p => (string[])p.Value).Distinct();
                            message = string.Join(" | ", errorMessages2);
                            break;
                        case var value when value != null && !(value is ProblemDetails):
                            message = badRequestObjectResult.Value.ToString();
                            break;
                    }

                    var apiResult = badRequestObjectResult.Value;
                    context.Result = new JsonResult(apiResult) { StatusCode = badRequestObjectResult.StatusCode };
                    break;
                }
                case ObjectResult notFoundObjectResult when notFoundObjectResult.StatusCode == 404:
                {
                    string message = null;
                    if (notFoundObjectResult.Value != null && !(notFoundObjectResult.Value is ProblemDetails))
                        message = notFoundObjectResult.Value.ToString();

                    //var apiResult = new ApiResult<object>(false, ApiResultStatusCode.NotFound, notFoundObjectResult.Value);
                    var apiResult = notFoundObjectResult.Value;
                    context.Result = new JsonResult(apiResult) { StatusCode = notFoundObjectResult.StatusCode };
                    break;
                }
                case ContentResult contentResult:
                {
                    var apiResult = new ResultCommand(true, ResultCode.Success, contentResult.Content);
                    context.Result = new JsonResult(apiResult) { StatusCode = contentResult.StatusCode };
                    break;
                }
                case ObjectResult objectResult when objectResult.StatusCode == null 
                                                    && !(objectResult.Value is ResultCommand):
                {
                    var apiResult = new ResultCommand(true, ResultCode.Success, objectResult.Value);
                    context.Result = new JsonResult(apiResult) { StatusCode = objectResult.StatusCode };
                    break;
                }
            }

            base.OnResultExecuting(context);
        }
    }
}