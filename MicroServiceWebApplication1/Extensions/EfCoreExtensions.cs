using Framework.EF;
using Framework.EF.Commands;
using Framework.EF.ContextFrameWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroServiceWebApplication1.Extensions
{
    public static class EfCoreExtensions
    {
        public static IServiceCollection AddEfCoreExtension(this IServiceCollection services, IConfiguration configuration)  
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationContextDb>>();
            services.AddTransient(typeof(TransactionalCommandHandler<>));
            return services;  
        }  
    }
}