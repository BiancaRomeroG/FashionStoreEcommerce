namespace FashionStoreEcommerce.Core.Domain.Orders
{
    public class CreateOrderFromCartDto
    {
        public List<CartProductDto> Items { get; set; } = [];
        public int CustomerId { get; set; }
    }
}
