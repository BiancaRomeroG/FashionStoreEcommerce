namespace FashionStoreEcommerce.Core.Domain.Products
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public static Category ToEntity(CategoryDto dto)
        {
            return new Category
            {
                Name = dto.Name
            };
        }

        public static CategoryDto FromEntity(Category entity)
        {
            return new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
