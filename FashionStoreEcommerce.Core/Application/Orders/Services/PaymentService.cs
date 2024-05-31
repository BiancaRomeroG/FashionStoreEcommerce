using FashionStoreEcommerce.Core.Application.Abstractions;
using FashionStoreEcommerce.Core.Domain.Orders;

namespace FashionStoreEcommerce.Core.Application.Orders.Services
{
    public class PaymentService(
        IPaymentRepository paymentRepository,
        IOrderRepository orderRepository,
        IUnitOfWork uof
        ) : IPaymentService
    {
        public async Task Add(Payment entity)
        {
            var order = await orderRepository.GetById(entity.OrderId) ?? throw new Exception("Order not found");
            order.Status = "Pagado";
            await orderRepository.Update(order);

            await paymentRepository.Add(entity);
            await uof.SaveChanges();
        }

        public async Task<bool> Delete(int id)
        {
            var result = await paymentRepository.Delete(id);
            if (!result)
            {
                return false;
            }
            await uof.SaveChanges();
            return true;
        }

        public async Task<List<Payment>> GetAll()
        {
            return await paymentRepository.GetAll();
        }

        public async Task<Payment?> GetById(int id)
        {
            return await paymentRepository.GetById(id);
        }

        public async Task<bool> Update(Payment entity)
        {
            var result = await paymentRepository.Update(entity);
            if (!result)
            {
                return false;
            }
            await uof.SaveChanges();
            return true;
        }
    }
}
