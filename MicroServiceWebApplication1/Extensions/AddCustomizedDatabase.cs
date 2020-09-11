
using Framework.EF;
using Framework.EF.ContextFrameWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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