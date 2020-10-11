using Framework.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroServiceWebApplication1.Extensions
{
    public static class AddCustomizedDatabase
    {
        public static void DatabaseCustomization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContextDb>(options =>
                options.UseMySql(configuration["ConnectionStrings:DefaultConnection"],
                    mySqlOptions => mySqlOptions.CommandTimeout(120)));
        }
    }
}