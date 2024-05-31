using FashionStoreEcommerce.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreEcommerce.Core.Application.Abstractions.Orders.Services
{
    public class OrderItemService(
        IOrderItemRepository orderItemRepository,
        IUnitOfWork uof
        ) : IOrderItemService
    {
        public async Task Add(OrderItem entity)
        {
            await orderItemRepository.Add(entity);
            await uof.SaveChanges();
        }

        public async Task<bool> Delete(int id)
        {
            var result = await orderItemRepository.Delete(id);
            if (!result)
            {
                return false;
            }
            await uof.SaveChanges();
            return true;
        }

        public async Task<List<OrderItem>> GetAll()
        {
            return await orderItemRepository.GetAll();
        }

        public async Task<OrderItem?> GetById(int id)
        {
            return await orderItemRepository.GetById(id);
        }

        public async Task<bool> Update(OrderItem entity)
        {
           var result = await orderItemRepository.Update(entity);
            if (!result)
            {
                return false;
            }
            await uof.SaveChanges();
            return true;
        }
    }
}
