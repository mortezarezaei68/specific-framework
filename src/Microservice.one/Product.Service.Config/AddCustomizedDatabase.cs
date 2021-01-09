using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.EfCore.Context;

namespace Microservice.Config
{
    public static class AddCustomizedDatabase
    {
        public static void DatabaseCustomization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContextDb>(options =>
                MySqlDbContextOptionsExtensions.UseMySql(options, configuration["ConnectionStrings:DefaultConnection"],
                    mySqlOptions => mySqlOptions.CommandTimeout(120)));
        }
    }
}