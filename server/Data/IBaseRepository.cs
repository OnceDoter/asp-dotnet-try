using Microsoft.AspNetCore.Mvc;
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
        ActionResult Create(T item);
        ActionResult Update(T item);
        ActionResult Delete(int id);
        Task SaveAsync();
    }
}
