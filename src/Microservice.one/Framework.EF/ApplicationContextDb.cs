using Framework.EF.Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace Framework.EF
{
    public class ApplicationContextDb : CoreDbContext
    {
        public ApplicationContextDb(DbContextOptions<ApplicationContextDb> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<TestAggregate> Aggregates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}