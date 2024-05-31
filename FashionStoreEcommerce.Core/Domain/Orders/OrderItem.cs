﻿using FashionStoreEcommerce.Core.Domain.Products;

namespace FashionStoreEcommerce.Core.Domain.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
