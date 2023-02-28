using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Framework.Exception.Exceptions.Extensions;


/// <summary>
/// Extensions for ServiceCollection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add custom type exception to problem details service registry.
    /// </summary>
    /// <param name="services"></param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services)
    {
        services.AddProblemDetails(x =>
        {
            // Control when an exception is included
            x.IncludeExceptionDetails = (ctx, _) =>
            {
                // Fetch services from HttpContext.RequestServices
                var env = ctx.RequestServices.GetRequiredService<IHostEnvironment>();
                return env.IsDevelopment() || env.IsStaging();
            };
            x.Map<ConflictException>(ex => new ProblemDetailsWithCode
            {
                Title = "Application rule broken",
                Status = StatusCodes.Status409Conflict,
                Detail = ex.Message,
                Type = "https://somedomain/application-rule-validation-error",
                Code = ex.Code
            });

            // Exception will produce and returns from our FluentValidation RequestValidationBehavior
            x.Map<ValidationException>(ex => new ProblemDetailsWithCode
            {
                Title = "input validation rules broken",
                Status = (int) ex.StatusCode,
                Detail = ex.Message,
                Type = "https://somedomain/input-validation-rules-error",
                Code = ex.Code
            });
            x.Map<BadRequestException>(ex => new ProblemDetailsWithCode
            {
                Title = "bad request exception",
                Status = StatusCodes.Status400BadRequest,
                Detail = ex.Message,
                Type = "https://somedomain/bad-request-error",
                Code = ex.Code
            });
            x.Map<NotFoundException>(ex => new ProblemDetailsWithCode
            {
                Title = "not found exception",
                Status = StatusCodes.Status404NotFound,
                Detail = ex.Message,
                Type = "https://somedomain/not-found-error",
                Code = ex.Code
            });
            x.Map<InternalServerException>(ex => new ProblemDetailsWithCode
            {
                Title = "api server exception",
                Status = StatusCodes.Status500InternalServerError,
                Detail = ex.Message,
                Type = "https://somedomain/api-server-error",
                Code = ex.Code
            });
            // x.Map<AppException>(ex => new ProblemDetailsWithCode
            // {
            //     Title = "application exception",
            //     Status = StatusCodes.Status500InternalServerError,
            //     Detail = ex.Message,
            //     Type = "https://somedomain/application-error",
            //     Code = ex.Code
            // });
            
            x.Map<TimeoutException>(ex => new ProblemDetailsWithCode
            {
                Title = "timeout exception",
                Status = StatusCodes.Status408RequestTimeout,
                Detail = ex.Message,
                Type = "https://somedomain/timeout-error"
            });

            x.Map<OperationCanceledException>(ex => new ProblemDetailsWithCode
            {
                Title = "operation cancel exception",
                Status = StatusCodes.Status408RequestTimeout,
                Detail = ex.Message,
                Type = "https://somedomain/operation-cancel-error"
            });
            
            x.Map<AntiforgeryValidationException>(ex => new ProblemDetailsWithCode
            {
                Title = "identity exception",
                Status = StatusCodes.Status400BadRequest,
                Detail = ex.Message,
                Type = "https://somedomain/identity-error"
            });

            x.MapToStatusCode<ArgumentNullException>(StatusCodes.Status400BadRequest);
            
            x.MapStatusCode = context =>
            {
                return context.Response.StatusCode switch
                {
                    StatusCodes.Status401Unauthorized => new ProblemDetailsWithCode
                    {
                        Status = context.Response.StatusCode,
                        Title = "identity exception",
                        Detail = "You are not Authorized",
                        Type = "https://somedomain/identity-error"
                    },

                    _ => new StatusCodeProblemDetails(context.Response.StatusCode)
                };
            };
            
            x.MapStatusCode = context =>
            {
                return context.Response.StatusCode switch
                {
                    StatusCodes.Status403Forbidden => new ProblemDetailsWithCode
                    {
                        Status = context.Response.StatusCode,
                        Title = "identity exception",
                        Detail = "Forbidden",
                        Type = "https://somedomain/identity-error"
                    },

                    _ => new StatusCodeProblemDetails(context.Response.StatusCode)
                };
            };
        });
        return services;
    }
}