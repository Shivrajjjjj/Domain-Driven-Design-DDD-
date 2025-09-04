using DddSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DddSample.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductPrice> ProductPrices => Set<ProductPrice>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Product mapping
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Sku)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(p => p.Name)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(p => p.CreatedAtUtc)
                      .IsRequired();

                // One-to-many relationship
                entity.HasMany(p => p.Prices)
                      .WithOne()
                      .HasForeignKey(pp => pp.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ProductPrice mapping
            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.ToTable("ProductPrice");
                entity.HasKey(pp => pp.Id);

                entity.Property(pp => pp.Currency)
                      .IsRequired()
                      .HasMaxLength(3);

                entity.Property(pp => pp.Amount)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();
            });
        }
    }
}
