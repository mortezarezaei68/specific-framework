using Framework.EF.ContextFrameWork;
using Framework.EF.Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace Framework.EF
{
    public class ApplicationContextDb:CoreDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TestAggregate> Aggregates { get; set; }

        public ApplicationContextDb(DbContextOptions<ApplicationContextDb> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}