using FashionStoreEcommerce.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreEcommerce.Core.Application.Abstractions.Orders.Services
{
    public class CustomerService(
        ICustomerRepository customerRepository,
        IUnitOfWork uof
        ) : ICustomerService
    {
        public async Task Add(Customer entity)
        {
            await customerRepository.Add( entity );
            await uof.SaveChanges();
        }

        public async Task<bool> Delete(int id)
        {
            var result = await customerRepository.Delete( id );
            if (!result)
            {
                return false;
            }
            await uof.SaveChanges();
            return true;

        }

        public async Task<List<Customer>> GetAll()
        {
            return await customerRepository.GetAll();
        }

        public async Task<Customer?> GetById(int id)
        {
            return await customerRepository.GetById( id );
        }

        public async Task<bool> Update(Customer entity)
        {
            var result = await customerRepository.Update( entity );
            if (!result)
            {
                return false;
            }
            await uof.SaveChanges();
            return true;
        }
    }
}
