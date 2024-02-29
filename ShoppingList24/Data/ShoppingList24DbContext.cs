using Microsoft.EntityFrameworkCore;
using ShoppingList24.Data.Models;

namespace ShoppingList24.Data
{
    public class ShoppingList24DbContext : DbContext
    {
        public ShoppingList24DbContext(DbContextOptions<ShoppingList24DbContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; } = null!;

        private Product FirstProduct { get; set; } = null!;

        private Product SecondProduct { get; set; } = null!;

        private DbSet<ProductNote> ProductNotes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedProducts();

            modelBuilder.Entity<Product>()
                .HasData(FirstProduct, SecondProduct);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedProducts()
        {
            FirstProduct = new Product()
            {
                Id = 1,
                Name = "Cheese"
            };

            SecondProduct = new Product()
            {
                Id = 2,
                Name = "Milk"
            };
        }
    }
}
