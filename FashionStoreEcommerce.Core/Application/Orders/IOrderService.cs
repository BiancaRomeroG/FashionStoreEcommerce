﻿using FashionStoreEcommerce.Core.Application.Abstractions;
using FashionStoreEcommerce.Core.Domain.Orders;

namespace FashionStoreEcommerce.Core.Application.Orders
{
    public interface IOrderService : IService<Order>
    {
        public Task<OrderWithItemsDto?> CreateOrderFromCart(CreateOrderFromCartDto cart);
    }
}
