namespace FashionStoreEcommerce.Core.Domain.Orders
{
    public class CreatePaymentDto
    {
        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public decimal Amount { get; set; }
        public static Payment ToEntity(CreatePaymentDto dto)
        {
            return new Payment
            {
                OrderId = dto.OrderId,
                PaymentDate = dto.PaymentDate,
                PaymentMethod = dto.PaymentMethod,
                Amount = dto.Amount
            };
        }
    }
}
