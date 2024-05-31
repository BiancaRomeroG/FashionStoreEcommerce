using FashionStoreEcommerce.Core.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreEcommerce.Infrastructure.Persistence.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
