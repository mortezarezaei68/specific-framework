using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Common
{
    public static class MediatRExtension
    {
        public static void MediatRInjection(this IServiceCollection services)
        {
            services.AddMediatR(typeof(IPipelineBehavior<,>).Assembly);
        }
    }
}