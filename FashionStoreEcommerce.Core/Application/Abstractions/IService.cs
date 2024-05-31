using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreEcommerce.Core.Application.Abstractions
{
    public interface IService<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(int id);
        Task Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }
}
