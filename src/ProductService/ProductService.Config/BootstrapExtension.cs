using System;
using Framework.Buses;
using Framework.Commands.CommandHandlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ProductService.Config
{
    public static class BootstrapExtension
    {
        public static IServiceCollection BootstrapExtensionService(this IServiceCollection services)
        {
            services.AddTransient(typeof(TransactionalCommandHandlerMediatR<,>));
            services.AddScoped<IEventBus, EventBus>();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped(typeof(IPipelineBehavior<,>),
                typeof(TransactionalCommandHandlerMediatR<,>));
            return services;
        }
    }
}