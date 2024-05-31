using FashionStoreEcommerce.Core.Application.Orders;
using FashionStoreEcommerce.Core.Domain.Orders;
using FashionStoreEcommerce.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreEcommerce.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository(AppDbContext context) : ICustomerRepository
    {
        public async Task Add(Customer entity)
        {
            await context.Customers.AddAsync(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var customer = await context.Customers.FindAsync(id);
            if (customer == null)
            {
                return false;
            }
            context.Customers.Remove(customer);
            return true;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetById(int id)
        {
            return await context.Customers.FindAsync(id);
        }

        public async Task<bool> Update(Customer entity)
        {
            var customer = await context.Customers.FindAsync(entity.Id);
            if (customer == null)
            {
                return false;
            }
            context.Entry(customer).CurrentValues.SetValues(entity);
            return true;
        }
    }
}
