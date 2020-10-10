using Framework.CQRS;
using Framework.CQRS.MediatRCommands;
using Framework.EF;
using Framework.EF.ContextFrameWork;
using Framework.EF.DomainEvents;
using Framework.EF.Framework.Domain;
using Framework.Events.DomainEvents.DomainEventAbstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroServiceWebApplication1.Extensions
{
    public static class EfCoreExtensions
    {
        public static IServiceCollection AddEfCoreExtension(this IServiceCollection services)  
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationContextDb>>();
            services.Scan(scan => scan
                .FromAssemblyOf<ChangedStatusCustomerDomainEventHandler>()
                .AddClasses(classes => classes.AssignableTo(typeof(IDomainEventHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            services.Scan(scan => scan
                .FromAssemblyOf<CreateCustomerTransactionalCommandHandler>()
                .AddClasses(classes => classes.AssignableTo(typeof(ITransactionalCommandHandlerMediatR<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ITestAggregateRepository, TestAggregateRepository>();
            return services;  
        }  
    }
}