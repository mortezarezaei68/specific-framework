using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ProductService.Persistance.Context
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContextDb>
    {
        public ApplicationContextDb CreateDbContext(string[] args)
        {
            var config = GetAppSetting();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContextDb>();
            optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnection"),ServerVersion.AutoDetect(config.GetConnectionString("DefaultConnection")));

            return new ApplicationContextDb(optionsBuilder.Options);
        }
        private IConfigurationRoot GetAppSetting()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var isDevelopment = environment == Environments.Development;
            if (isDevelopment)
                return new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())    
                    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                    .Build();

            return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())    
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}