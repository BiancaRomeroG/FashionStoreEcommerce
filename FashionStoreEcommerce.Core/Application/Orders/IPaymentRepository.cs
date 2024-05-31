using FashionStoreEcommerce.Core.Application.Abstractions;
using FashionStoreEcommerce.Core.Domain.Orders;

namespace FashionStoreEcommerce.Core.Application.Orders
{
    public interface IPaymentRepository : IRepository<Payment>
    {
    }
}
