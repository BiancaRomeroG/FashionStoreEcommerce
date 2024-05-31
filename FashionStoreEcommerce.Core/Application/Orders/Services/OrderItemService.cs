using FashionStoreEcommerce.Core.Application.Abstractions;
using FashionStoreEcommerce.Core.Domain.Orders;

namespace FashionStoreEcommerce.Core.Application.Orders.Services
{
    public class OrderItemService(
        IOrderItemRepository orderItemRepository,
        IOrderRepository orderRepository,
        IUnitOfWork uof
        ) : IOrderItemService
    {
        public async Task Add(OrderItem entity)
        {
            var order = await orderRepository.GetById(entity.OrderId);
            if (order == null)
            {
                throw new Exception("Order not found");
            }

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
