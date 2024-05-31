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
    public class OrderItemRepository(AppDbContext context) : IOrderItemRepository
    {
        public async Task Add(OrderItem entity)
        {
            await context.OrderItems.AddAsync(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var orderItem = await context.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                return false;
            }
            context.OrderItems.Remove(orderItem);
            return true;
        }

        public async Task<List<OrderItem>> GetAll()
        {
            return await context.OrderItems.ToListAsync();
        }

        public async Task<OrderItem?> GetById(int id)
        {
            return await context.OrderItems.FindAsync(id);

        }

        public async Task<bool> Update(OrderItem entity)
        {
            var orderItem = await context.OrderItems.FindAsync(entity.Id);
            if (orderItem == null)
            {
                return false;
            }
            context.Entry(orderItem).CurrentValues.SetValues(entity);
            return true;
        }
    }
}
