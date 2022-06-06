using Microsoft.EntityFrameworkCore;
namespace ProductManagementSystem.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext (DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData
                (
                new Product { Id = 1, Name = "Bokuto", Description = "Wooden Training Sword", Price = 24.99M, ImageName = "woodensword.jpg" },
                new Product { Id = 2, Name = "Rubber Sais", Description = "Rubber Training Sais", Price = 15.00M, ImageName = "rubbersai.jpg" },
                new Product { Id = 3, Name = "Rubber Combat Knife", Description = "Rubber Training Knife for Training", Price = 14.99M, ImageName = "rubberknife.jpg" }

                );
        }
    }
}
