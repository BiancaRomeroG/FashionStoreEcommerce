using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreEcommerce.Core.Domain.Orders
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public static Order ToEntity(CreateOrderDto dto)
        {
            return new Order
            {
                CustomerId = dto.CustomerId,
                Status = dto.Status,
                CreatedAt = dto.CreatedAt,
            };
        }
    }
}
