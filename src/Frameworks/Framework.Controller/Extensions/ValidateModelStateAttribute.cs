using System;
using System.Linq;
using Common;
using Framework.Commands.CommandHandlers;
using Framework.Exception.Exceptions.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Framework.Controller.Extensions
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;
            
            
            var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                .SelectMany(v => v.Errors)
                .Select(v => v.ErrorMessage)
                .ToList();
            

            var apiResult = new ResponseCommand(false, ResultCode.BadRequest, String.Join(", ", errors.ToArray()));
            context.Result = new JsonResult(apiResult) { StatusCode = 400 };
        }
    }
}