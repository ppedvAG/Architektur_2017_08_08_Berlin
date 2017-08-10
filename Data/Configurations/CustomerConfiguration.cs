using Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configurations
{
    internal class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ToTable("Kunden");

            Property(c => c.Firstname)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Lastname)
                .IsRequired()
                .HasMaxLength(50);

            HasMany(c => c.Products)
                .WithMany(p => p.Customers)
                .Map(m =>
                {
                    m.ToTable("KundenProdukte");
                    m.MapLeftKey("KundenId");
                    m.MapRightKey("ProduktId");
                });
        }
    }
}
