﻿namespace FashionStoreEcommerce.Core.Domain.Orders
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Nit { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
