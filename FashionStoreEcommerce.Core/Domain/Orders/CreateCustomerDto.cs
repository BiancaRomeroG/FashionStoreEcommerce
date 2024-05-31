namespace FashionStoreEcommerce.Core.Domain.Orders
{
    public class CreateCustomerDto
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Nit { get; set; }
        public DateTime CreatedAt { get; set; }
        public static Customer ToEntity(CreateCustomerDto dto)
        {
            return new Customer
            {
                Name = dto.Name,
                Address = dto.Address,
                Nit = dto.Nit,
                CreatedAt = dto.CreatedAt
            };
        }
    }
}
