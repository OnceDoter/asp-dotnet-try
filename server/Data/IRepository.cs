using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetList();
        Task<T> Get(int id);
        ActionResult Create(T item);
        ActionResult Create(IEnumerable<T> seq);
        ActionResult Update(T item);
        ActionResult Delete(int id);
        Task SaveAsync();
    }
}
