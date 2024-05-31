using FashionStoreEcommerce.Core.Application.Abstractions;
using Microsoft.EntityFrameworkCore.Storage;

namespace FashionStoreEcommerce.Infrastructure.Persistence.Data
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private IDbContextTransaction? _currentTransaction;

        public async Task BeginTransaction()
        {
            if (_currentTransaction != null)
            {
                throw new InvalidOperationException("There is already a transaction in progress.");
            }

            _currentTransaction = await context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            if (_currentTransaction == null)
            {
                throw new InvalidOperationException("There is no transaction in progress.");
            }

            try
            {
                await context.SaveChangesAsync();
                await _currentTransaction.CommitAsync();
            }
            catch
            {
                await RollbackTransaction();
                throw;
            }
            finally
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }

        public async Task RollbackTransaction()
        {
            if (_currentTransaction == null)
            {
                throw new InvalidOperationException("There is no transaction in progress.");
            }

            try
            {
                await _currentTransaction.RollbackAsync();
            }
            finally
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
