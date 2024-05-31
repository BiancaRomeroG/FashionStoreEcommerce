using FashionStoreEcommerce.Core.Application.Abstractions;
using FashionStoreEcommerce.Core.Application.Products;
using FashionStoreEcommerce.Core.Domain.Orders;

namespace FashionStoreEcommerce.Core.Application.Orders.Services
{
    public class OrderService(
        IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository,
        IProductRepository productRepository,
        IUnitOfWork uof
        ) : IOrderService
    {
        public async Task Add(Order entity)
        {
            await orderRepository.Add(entity);
            await uof.SaveChanges();
        }

        public async Task<OrderWithItemsDto?> CreateOrderFromCart(CreateOrderFromCartDto cart)
        {
            await uof.BeginTransaction();

            foreach (var item in cart.Items)
            {
                var product = await productRepository.GetById(item.ProductId);
                if (product == null || product.Stock < item.Quantity)
                {
                    await uof.RollbackTransaction();
                    return null;
                }
            }

            var order = new Order
            {
                CreatedAt = DateTime.Now,
                CustomerId = cart.CustomerId,
                Status = "Pendiente",
            };

            await orderRepository.Add(order);
            await uof.SaveChanges();

            decimal subTotal = 0m;
            List<OrderItem> orderItems = [];

            foreach (var item in cart.Items)
            {
                var product = await productRepository.GetById(item.ProductId);
                if (product == null)
                {
                    await uof.RollbackTransaction();
                    return null;
                }

                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price,
                };
                await orderItemRepository.Add(orderItem);
                await uof.SaveChanges();

                product.Stock -= item.Quantity;
                await productRepository.Update(product);
                await uof.SaveChanges();

                orderItems.Add(orderItem);
                subTotal += product.Price * item.Quantity;
            }

            await uof.CommitTransaction();
            decimal tax = subTotal * Taxes.IVA;

            var itemsDto = orderItems.Select(item => new OrderItemDto
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                OrderId = item.OrderId,
            }).ToList();

            return new OrderWithItemsDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                CreatedAt = order.CreatedAt,
                Status = order.Status,
                Items = itemsDto,
                SubTotal = subTotal,
                Tax = tax,
                Total = subTotal + tax,
            };
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
