using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreEcommerce.Core.Domain.Orders
{
    public class CreatePaymentDto
    {
        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public static Payment ToEntity(CreatePaymentDto dto)
        {
            return new Payment
            {
                OrderId = dto.OrderId,
                PaymentDate = dto.PaymentDate,
                PaymentMethod = dto.PaymentMethod,
                SubTotal = dto.SubTotal,
                TaxAmount = dto.TaxAmount
            };
        }
    }
}
