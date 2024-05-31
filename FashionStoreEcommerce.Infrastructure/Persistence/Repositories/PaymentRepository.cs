using FashionStoreEcommerce.Core.Application.Abstractions.Orders;
using FashionStoreEcommerce.Core.Domain.Orders;
using FashionStoreEcommerce.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreEcommerce.Infrastructure.Persistence.Repositories
{
    public class PaymentRepository(AppDbContext context) : IPaymentRepository
    {
        public async Task Add(Payment entity)
        {
            await context.Payments.AddAsync(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var payment = await context.Payments.FindAsync(id);
            if (payment == null)
            {
                return false;
            }
            context.Payments.Remove(payment);
            return true;
        }

        public async Task<List<Payment>> GetAll()
        {
            return await context.Payments.ToListAsync();
        }

        public async Task<Payment?> GetById(int id)
        {
           return await context.Payments.FindAsync(id);
        }

        public async Task<bool> Update(Payment entity)
        {
            var payment = await context.Payments.FindAsync(entity.Id);
            if (payment == null)
            {
                return false;
            }
            context.Entry(payment).CurrentValues.SetValues(entity);
            return true;
        }
    }
}
