using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FinalProjectRyan.Models
{
    public class CartContext : IdentityDbContext<AdminUser>
    {
        public CartContext(DbContextOptions<CartContext> options)
            : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Products> Products { get; set; } = null!;
        //public DbSet<AdminUser> AdminUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AdminUser>().HasData(
                new AdminUser { UserName = "Admin", NormalizedUserName = "ADMIN" });

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Laptops" },
                new Category { CategoryID = 2, CategoryName = "Desktops"},
                new Category { CategoryID = 3, CategoryName = "Monitors" },
                new Category { CategoryID = 4, CategoryName = "Keyboards" },
                new Category { CategoryID = 5, CategoryName = "Headsets" }
                );

            modelBuilder.Entity<Products>().HasKey(p => p.ProductID);

            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    ProductID = 1,
                    CategoryID = 1,
                    ProductBrand = "ASUS",
                    ProductModel = "TUF DASH F15",
                    ProductPrice = (double)1299.99
                },
                new Products
                {
                    ProductID = 2,
                    CategoryID = 2,
                    ProductBrand = "Corsair",
                    ProductModel = "VENGEANCE i7200 Gaming PC",
                    ProductPrice = (double)1999.99
                },
                new Products
                {
                    ProductID = 3,
                    CategoryID = 3,
                    ProductBrand = "Samsung",
                    ProductModel = "27in Odyssey G32A FHD 1ms 165Hz Gaming Monitor w/ Free Sync",
                    ProductPrice = (double)189.99
                },
                new Products
                {
                    ProductID = 4,
                    CategoryID = 4,
                    ProductBrand = "Logitech",
                    ProductModel = "G Pro Mechanical Gaming Keyboard",
                    ProductPrice = (double)90.99
                },
                new Products
                {
                    ProductID = 5,
                    CategoryID = 5,
                    ProductBrand = "Logitech",
                    ProductModel = "G733 Lightspeed Wireless Gaming Headset w/ Suspension Headband, Lightsync RGB, Blue Voice Mic Technology - Black",
                    ProductPrice = (double)133.99
                }
                );
        }
    }
}
