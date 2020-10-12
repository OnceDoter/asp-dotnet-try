using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class ContentRepository<T> : IRepository<T>
        where T : class
    {
        private readonly WebApiDbContext _context;

        public ContentRepository(WebApiDbContext context)
            => this._context = context;

        public ActionResult Create(T item)
            => TryToChangeEntity(() 
                => _context.Add(item));

        public ActionResult Create(IEnumerable<T> seq)
        {
            foreach (var elem in seq)
                TryToChangeEntity(()
                    => _context.Add(elem));
            return new OkResult();
        }

        public ActionResult Delete(int id)
            => TryToChangeEntity(() 
                => _context.Remove(_context.Find<T>(id)));

        public ActionResult Update(T item)
            => TryToChangeEntity(()
                => _context.Update(item));

        public async Task<T> Get(int id)
            => await _context.FindAsync<T>(id);

        public IEnumerable<T> GetList()
            => _context.Set<T>().AsEnumerable();

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();

        private ActionResult TryToChangeEntity(Action action)
        {
            try
            {
                action();
                _context.SaveChanges();
                return new OkResult();
            }
            catch (DbUpdateConcurrencyException e)
            {
                foreach (var entry in e.Entries)
                    if (entry.Entity is T)
                    {
                        var proposedValues = entry.CurrentValues;
                        var databaseValues = entry.GetDatabaseValues();
                        foreach (var property in proposedValues.Properties)
                            proposedValues[property] = databaseValues[property];
                        entry.OriginalValues.SetValues(databaseValues);
                        return new OkResult();
                    }
                    else
                        throw new NotSupportedException("Don't know how to handle concurrency conflicts for " + entry.Metadata.Name);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
            return new BadRequestResult();
        }
        public void Dispose()
            => _context.Dispose();
    }
}
