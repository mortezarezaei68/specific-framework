using System;
using Framework.CQRS.CommandBus;
using Framework.CQRS.MediatRCommands;
using Framework.EF.DomainEvents;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication.Extensions
{
    public static class BootstrapExtension
    {
        public static IServiceCollection BootstrapExtensionService(this IServiceCollection services)
        {
            services.AddScoped<IServiceLocator, ServiceLocator>();
            services.AddScoped<ICommandBus, CommandBus>();      
            services.AddTransient(typeof(TransactionalTransactionalCommandHandlerMediatR<,>));
            services.AddScoped<IEventBus, EventBus>();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionalTransactionalCommandHandlerMediatR<,>));
            return services;
        } 
    }
}