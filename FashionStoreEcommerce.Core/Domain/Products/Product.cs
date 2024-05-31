namespace FashionStoreEcommerce.Core.Domain.Products
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
        public string Status { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public Category? Category { get; set; }
    }
}
