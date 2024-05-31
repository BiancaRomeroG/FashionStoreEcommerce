using FashionStoreEcommerce.Core.Application.Abstractions.Orders;
using FashionStoreEcommerce.Core.Domain.Orders;
using FashionStoreEcommerce.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreEcommerce.Infrastructure.Persistence.Repositories
{
    public class OrderRepository(AppDbContext context) : IOrderRepository
    {
        public async Task Add(Order entity)
        {
            await context.Orders.AddAsync(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var order = await context.Orders.FindAsync(id);
            if (order == null)
            {
                return false;
            }
            context.Orders.Remove(order);
            return true;
        }

        public async Task<List<Order>> GetAll()
        {
            return await context.Orders.ToListAsync();
        }

        public async Task<Order?> GetById(int id)
        {
            return await context.Orders.FindAsync(id);
        }

        public async Task<bool> Update(Order entity)
        {
            var order = await context.Orders.FindAsync(entity.Id);
            if (order == null)
            {
                return false;
            }
            context.Entry(order).CurrentValues.SetValues(entity);
            return true;
        }
    }
}
