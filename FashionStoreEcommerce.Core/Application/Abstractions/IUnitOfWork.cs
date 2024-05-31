namespace FashionStoreEcommerce.Core.Application.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
        Task<int> SaveChanges();
    }
}
