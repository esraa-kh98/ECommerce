using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class EcommerceDbContext:DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options):base(options)
        {}
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderItem> OrderItems { set; get; }
        public DbSet<ShoppingCartItem> shoppingCartItems { set; get; }
    }
}
