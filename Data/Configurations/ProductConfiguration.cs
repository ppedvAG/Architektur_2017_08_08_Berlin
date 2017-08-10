using Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configurations
{
    internal class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Produkte");

            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            Property(p => p.Number)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
