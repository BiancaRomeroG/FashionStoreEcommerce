using FashionStoreEcommerce.Core.Application.Abstractions;
using FashionStoreEcommerce.Core.Domain.Products;

namespace FashionStoreEcommerce.Core.Application.Products.Services
{
    public class CategoryService(
        ICategoryRepository categoryRepository,
        IUnitOfWork uof
        ) : ICategoryService
    {
        public async Task Add(Category entity)
        {
            await categoryRepository.Add(entity);
            await uof.SaveChanges();
        }

        public async Task<bool> Delete(int id)
        {
            var result = await categoryRepository.Delete(id);
            if (!result)
            {
                return false;
            }

            await uof.SaveChanges();
            return true;
        }

        public async Task<List<Category>> GetAll()
        {
            return await categoryRepository.GetAll();
        }

        public async Task<Category?> GetById(int id)
        {
            return await categoryRepository.GetById(id);
        }

        public async Task<bool> Update(Category entity)
        {
            var result = await categoryRepository.Update(entity);
            if (!result)
            {
                return false;
            }

            await uof.SaveChanges();
            return true;
        }
    }
}
