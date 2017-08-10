using Core.Models;
using Data.Configurations;
using System.Data.Entity;

namespace Data
{
    public class FroshDbContext : DbContext
    {
        public FroshDbContext(string nameOrConnectionString) 
            : base(nameOrConnectionString)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
        }
    }
}
