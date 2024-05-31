using FashionStoreEcommerce.Core.Application.Products;
using FashionStoreEcommerce.Core.Domain.Products;
using FashionStoreEcommerce.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreEcommerce.Infrastructure.Persistence.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        public async Task Add(Product entity)
        {
            await context.Products.AddAsync(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            context.Products.Remove(product);
            return true;
        }

        public async Task<List<Product>> GetAll()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task<bool> Update(Product entity)
        {
            var product = await context.Products.FindAsync(entity.Id);
            if (product == null)
            {
                return false;
            }
            context.Entry(product).CurrentValues.SetValues(entity);
            return true;
        }
    }
}
