using Framework.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MicroServiceWebApplication1.Extensions
{
    public static class SeedData
    {
        public static void IntializedDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var imaContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationContextDb>();
            imaContext.Database.EnsureCreated();
            imaContext.Database.Migrate();
        }
    }
}