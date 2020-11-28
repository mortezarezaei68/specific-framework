using EventBase.CommandHandlers;
using EventBase.DomainEvents;
using Framework.Domain;
using Microservice.Domain;
using Microsoft.Extensions.DependencyInjection;
using Persistance.EfCore.Context;
using Persistance.EfCore.Repository;
using Persistance.EfCore.UnitOfWork;

namespace Microservice.Config
{
    public static class EfCoreExtensions
    {
        public static IServiceCollection AddEfCoreExtension(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationContextDb>>();
            // services.Scan(scan => scan
            //     .FromAssemblyOf<ChangedStatusCustomerDomainEventHandler>()
            //     .AddClasses(classes => classes.AssignableTo(typeof(IDomainEventHandler<>)))
            //     .AsImplementedInterfaces()
            //     .WithScopedLifetime());
            // services.Scan(scan => scan
            //     .FromAssemblyOf<CreateCustomerTransactionalCommandHandler>()
            //     .AddClasses(classes => classes.AssignableTo(typeof(ITransactionalCommandHandlerMediatR<,>)))
            //     .AsImplementedInterfaces()
            //     .WithScopedLifetime());
            services.AddTransient<IProductRepository, ProductRepository>();
            return services;
        }
    }
}