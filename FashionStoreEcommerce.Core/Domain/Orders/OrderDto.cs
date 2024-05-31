using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreEcommerce.Core.Domain.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public static Order ToEntity(OrderDto dto)
        {
            return new Order
            {
                Id = dto.Id,
                CustomerId = dto.CustomerId,
                Status = dto.Status,
                CreatedAt = dto.CreatedAt

            };
        }
        public static OrderDto FromEntity(Order entity)
        {
            return new OrderDto
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                Status = entity.Status,
                CreatedAt = entity.CreatedAt,
            };
        }
    }
}
