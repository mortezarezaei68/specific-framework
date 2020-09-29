using System;
using Framework.CQRS.CommandCustomize;
using Framework.EF.Commands;
using Framework.EF.DomainEvents;
using MediatR;
using MicroServiceWebApplication1.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace MicroServiceWebApplication1.Extensions
{
    public static class BootstrapExtension
    {
        public static IServiceCollection BootstrapExtensionService(this IServiceCollection services)
        {
            services.AddScoped<IServiceLocator, ServiceLocator>();
            services.AddScoped<ICommandBus, CommandBus>();      
            services.AddTransient(typeof(TransactionalCommandHandlerCustomize<,>));
            services.AddScoped<IEventBus, EventBus>();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionalCommandHandlerCustomize<,>));
            return services;
        } 
    }
}