using Framework.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MicroServiceWebApplication1.Extensions
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContextDb>
    {
        public ApplicationContextDb CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContextDb>();
            optionsBuilder.UseMySql("server=localhost;port=3306;userid=root;password=123456;database=TestDb;");

            return new ApplicationContextDb(optionsBuilder.Options);
        }
    }
}