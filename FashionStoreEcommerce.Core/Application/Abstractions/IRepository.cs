namespace FashionStoreEcommerce.Core.Application.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(int id);
        Task Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }
}
