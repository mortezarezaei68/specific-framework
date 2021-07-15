using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Persistence.Context;

namespace ProductService.Config
{
    public static class AddCustomizedDatabase
    {
        public static void DatabaseCustomization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContextDb>(options =>
                options.UseMySql(configuration["ConnectionStrings:DefaultConnection"],ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]),
                    mySqlOptions => mySqlOptions.CommandTimeout(120)));
        }
    }
}