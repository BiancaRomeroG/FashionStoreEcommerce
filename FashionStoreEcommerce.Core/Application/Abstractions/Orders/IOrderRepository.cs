using FashionStoreEcommerce.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreEcommerce.Core.Application.Abstractions.Orders
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}
