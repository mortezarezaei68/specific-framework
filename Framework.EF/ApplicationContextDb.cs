using Framework.EF.ContextFrameWork;
using Microsoft.EntityFrameworkCore;

namespace Framework.EF
{
    public class ApplicationContextDb:CoreDbContext
    {
        public DbSet<Customer> Customers;
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