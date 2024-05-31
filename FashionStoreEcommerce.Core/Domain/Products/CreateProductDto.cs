using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreEcommerce.Core.Domain.Products
{
    public class CreateProductDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
        public string Status { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public static Product ToEntity(CreateProductDto dto)
        {
            return new Product
            {
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                Status = dto.Status,
                ImageUrl = dto.ImageUrl
            };
        }
    }
}
