namespace HalloReverceEngeneering
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FroschDbContext : DbContext
    {
        public FroschDbContext()
            : base("name=FroschDbContext")
        {
        }

        public virtual DbSet<Kunden> Kundens { get; set; }
        public virtual DbSet<Produkte> Produktes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kunden>()
                .HasMany(e => e.Produktes)
                .WithMany(e => e.Kundens)
                .Map(m => m.ToTable("KundenProdukte").MapLeftKey("KundenId").MapRightKey("ProduktId"));

            modelBuilder.Entity<Produkte>()
                .Property(e => e.Number)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Produkte>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
