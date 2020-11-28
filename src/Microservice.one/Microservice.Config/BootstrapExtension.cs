using System;
using EventBase.CommandHandlers;
using EventBase.EventBusBase;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Config
{
    public static class BootstrapExtension
    {
        public static IServiceCollection BootstrapExtensionService(this IServiceCollection services)
        {
            services.AddTransient(typeof(TransactionalTransactionalCommandHandlerMediatR<,>));
            services.AddScoped<IEventBus, EventBus>();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped(typeof(IPipelineBehavior<,>),
                typeof(TransactionalTransactionalCommandHandlerMediatR<,>));
            return services;
        }
    }
}