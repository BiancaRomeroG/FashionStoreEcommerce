using FashionStoreEcommerce.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreEcommerce.Core.Domain.Orders
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Nit { get; set; }
        public DateTime CreatedAt { get; set; }

        public static Customer ToEntity(CustomerDto dto)
        {
            return new Customer
            {
                Id = dto.Id,
                Name = dto.Name,
                Address = dto.Address,
                Nit = dto.Nit,
                CreatedAt = dto.CreatedAt

            };
        }

        public static CustomerDto FromEntity(Customer entity)
        {
            return new CustomerDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Address = entity.Address,
                Nit = entity.Nit,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
