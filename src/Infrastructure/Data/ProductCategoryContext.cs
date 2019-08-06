using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductCategoryContext : DbContext
    {
        public ProductCategoryContext()
        {
        }

        public ProductCategoryContext(DbContextOptions<ProductCategoryContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>()
                .HasIndex(o => new { o.Id })
                .IsUnique();

        }
    }
}
