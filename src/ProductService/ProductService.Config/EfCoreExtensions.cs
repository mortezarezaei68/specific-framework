using Framework.Commands.CommandHandlers;
using Framework.Domain.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using ProductCommand.Contract;
using ProductService.Domain;
using ProductService.Persistance.Context;
using ProductService.Persistance.Repository;
using ProductService.Persistance.UnitOfWork;

namespace ProductService.Config
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