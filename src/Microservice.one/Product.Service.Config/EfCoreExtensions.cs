using Framework.Domain;
using Framework.EventBase.CommandHandlers;
using Microservice.Domain;
using Microsoft.Extensions.DependencyInjection;
using Persistance.EfCore.Context;
using Persistance.EfCore.Repository;
using Persistance.EfCore.UnitOfWork;
using Product.Command.Contract;

namespace Product.Service.Config
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
            services.Scan(scan => scan
                .FromAssemblyOf<CreateProductTransactionalCommandHandler>()
                .AddClasses(classes => classes.AssignableTo(typeof(ITransactionalCommandHandlerMediatR<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            services.AddTransient<IProductRepository, ProductRepository>();
            return services;
        }
    }
}