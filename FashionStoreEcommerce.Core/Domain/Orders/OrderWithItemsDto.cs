namespace FashionStoreEcommerce.Core.Domain.Orders
{
    public class OrderWithItemsDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public List<OrderItemDto> Items { get; set; } = [];
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
}
