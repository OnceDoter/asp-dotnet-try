using AngularWebApi.Data;
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
        // TODO: Multithreading try\catch
        private readonly WebApiDbContext context;

        public ContentRepository(WebApiDbContext context)
            => this.context = context;

        public ActionResult Create(T item)
            => tryToChangeEntity(() 
                => context.Add(item));

        public ActionResult Delete(int id)
        => tryToChangeEntity(() 
            => context.Remove(context.Find<T>(id)));

        public ActionResult Update(T item)
        => tryToChangeEntity(()
            => context.Update(item));

        public void Dispose()
            => context.Dispose();

        public async Task<T> Get(int id)
            => await context.FindAsync<T>(id);

        public IEnumerable<T> GetList()
        {
            DbSet<T> set = context.Set<T>();
            return set.AsEnumerable<T>();
        }

        public async Task SaveAsync()
        => await context.SaveChangesAsync();

        private ActionResult tryToChangeEntity(Action action)
        {
            try
            {
                action();
                context.SaveChanges();
                return new OkResult();
            }
            catch (DbUpdateConcurrencyException e)
            {
                foreach (var entry in e.Entries)
                {
                    if (entry.Entity is T)
                    {
                        var proposedValues = entry.CurrentValues;
                        var databaseValues = entry.GetDatabaseValues();

                        foreach (var property in proposedValues.Properties)
                        {
                            var proposedValue = proposedValues[property];
                            var databaseValue = databaseValues[property];

                            // TODO: decide which value should be written to database
                            // proposedValues[property] = <value to be saved>;
                        }

                        // Refresh original values to bypass next concurrency check
                        entry.OriginalValues.SetValues(databaseValues);
                        return new OkResult();
                    }
                    else
                    {
                        throw new NotSupportedException(
                            "Don't know how to handle concurrency conflicts for "
                            + entry.Metadata.Name);
                    }
                }
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
            return new BadRequestResult();
        }

    }
}
