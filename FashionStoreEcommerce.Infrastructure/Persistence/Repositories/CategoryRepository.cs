using FashionStoreEcommerce.Core.Application.Products;
using FashionStoreEcommerce.Core.Domain.Products;
using FashionStoreEcommerce.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreEcommerce.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        public async Task Add(Category entity)
        {
            await context.Categories.AddAsync(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            context.Categories.Remove(category);
            return true;
        }

        public async Task<List<Category>> GetAll()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(int id)
        {
            return await context.Categories.FindAsync(id);
        }

        public async Task<bool> Update(Category entity)
        {
            var category = await context.Categories.FindAsync(entity.Id);
            if (category == null)
            {
                return false;
            }

            context.Entry(category).CurrentValues.SetValues(entity);
            return true;
        }
    }
}
