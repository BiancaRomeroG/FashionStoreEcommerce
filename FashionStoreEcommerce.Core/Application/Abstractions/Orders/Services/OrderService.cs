using FashionStoreEcommerce.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreEcommerce.Core.Application.Abstractions.Orders.Services
{
    public class OrderService(
        IOrderRepository orderRepository,
        IUnitOfWork uof
        ) : IOrderService
    {
        public async Task Add(Order entity)
        {
            await orderRepository.Add(entity);
            await uof.SaveChanges();
        }

        public async Task<bool> Delete(int id)
        {
            var result = await orderRepository.Delete(id);
            if (!result)
            {
                return false;
            }
            await uof.SaveChanges();
            return true;

        }

        public async Task<List<Order>> GetAll()
        {
            return await orderRepository.GetAll();
        }

        public async Task<Order?> GetById(int id)
        {
            return await orderRepository.GetById(id);
        }

        public async Task<bool> Update(Order entity)
        {
            var result = await orderRepository.Update(entity);
            if (!result)
            {
                return false;
            }
            await uof.SaveChanges();
            return true;
        }
    }
}
