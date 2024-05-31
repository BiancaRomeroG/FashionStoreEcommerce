namespace FashionStoreEcommerce.Core.Domain.Products
{
    public class CreateCategoryDto
    {
        public string Name { get; set; } = null!;

        public static Category ToEntity(CreateCategoryDto dto)
        {
            return new Category
            {
                Name = dto.Name
            };
        }
    }
}
