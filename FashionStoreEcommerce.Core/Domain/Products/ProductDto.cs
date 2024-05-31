namespace FashionStoreEcommerce.Core.Domain.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
        public string Status { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        public static Product ToEntity(ProductDto dto)
        {
            return new Product
            {
                Id = dto.Id,
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                Status = dto.Status,
                ImageUrl = dto.ImageUrl
            };
        }

        public static ProductDto FromEntity(Product entity)
        {
            return new ProductDto
            {
                Id = entity.Id,
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Stock = entity.Stock,
                Status = entity.Status,
                ImageUrl = entity.ImageUrl,

            };
        }
    }
}
