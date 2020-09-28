using Framework.EF;
using Framework.EF.Commands;
using Framework.EF.ContextFrameWork;
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
                .FromAssemblyOf<CreateCustomerCommandHandler>()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            return services;  
        }  
    }
}