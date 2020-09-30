using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Data
{
    interface IBaseRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetList();
        Task<T> Get(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
        Task SaveAsync();
    }
}
