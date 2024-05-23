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
    }
}
