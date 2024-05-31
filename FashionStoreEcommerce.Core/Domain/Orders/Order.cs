using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreEcommerce.Core.Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public Customer? Customer { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = [];
    }
}
