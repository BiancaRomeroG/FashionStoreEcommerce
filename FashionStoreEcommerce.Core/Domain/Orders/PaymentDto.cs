namespace FashionStoreEcommerce.Core.Domain.Orders
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public static Payment ToEntity(PaymentDto dto)
        {
            return new Payment
            {
                Id = dto.Id,
                OrderId = dto.OrderId,
                PaymentDate = dto.PaymentDate,
                PaymentMethod = dto.PaymentMethod,
                SubTotal = dto.SubTotal,
                TaxAmount = dto.TaxAmount
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
                SubTotal = entity.SubTotal,
                TaxAmount = entity.TaxAmount
            };
        }
    }
}
