using FashionStoreEcommerce.Core.Application.Abstractions;
using FashionStoreEcommerce.Core.Domain.Products;

namespace FashionStoreEcommerce.Core.Application.Products.Services
{
    public class ProductService(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        IUnitOfWork uof
        ) : IProductService


    {
        public async Task Add(Product entity)
        {
            var category = await categoryRepository.GetById(entity.CategoryId) ?? throw new Exception("Category not found");
            await productRepository.Add(entity);
            await uof.SaveChanges();
        }

        public async Task<bool> Delete(int id)
        {
            var result = await productRepository.Delete(id);
            if (!result)
            {
                return false;
            }
            await uof.SaveChanges();
            return true;
        }

        public async Task<List<Product>> GetAll()
        {
            return await productRepository.GetAll();
        }

        public async Task<Product?> GetById(int id)
        {
            return await productRepository.GetById(id);
        }

        public async Task<bool> Update(Product entity)
        {
            var result = await productRepository.Update(entity);
            if (!result)
            {
                return false;
            }
            await uof.SaveChanges();
            return true;
        }
    }
}
