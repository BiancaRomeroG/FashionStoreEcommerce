using FashionStoreEcommerce.Core.Domain.Orders;
using FashionStoreEcommerce.Core.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreEcommerce.Infrastructure.Persistence.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
