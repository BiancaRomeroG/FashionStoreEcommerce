﻿using FashionStoreEcommerce.Core.Application.Abstractions;
using FashionStoreEcommerce.Core.Domain.Orders;

namespace FashionStoreEcommerce.Core.Application.Orders
{
    public interface IOrderItemService : IService<OrderItem>
    {
    }
}