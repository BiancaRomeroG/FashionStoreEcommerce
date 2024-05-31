namespace FashionStoreEcommerce.Core.Domain.Orders
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public decimal Amount { get; set; }
        public Order? Order { get; set; }
    }
}
