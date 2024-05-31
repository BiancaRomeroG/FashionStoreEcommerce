namespace FashionStoreEcommerce.Core.Domain.Orders
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public decimal Amount { get; set; }
        public static Payment ToEntity(PaymentDto dto)
        {
            return new Payment
            {
                Id = dto.Id,
                OrderId = dto.OrderId,
                PaymentDate = dto.PaymentDate,
                PaymentMethod = dto.PaymentMethod,
                Amount = dto.Amount
                
            };
        }
        public static PaymentDto FromEntity(Payment entity)
        {
            return new PaymentDto
            {
                Id = entity.Id,
                OrderId = entity.OrderId,
                PaymentDate = entity.PaymentDate,
                PaymentMethod = entity.PaymentMethod,
                Amount = entity.Amount
                
            };
        }
    }
}
