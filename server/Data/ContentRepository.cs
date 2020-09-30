using AngularWebApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class ContentRepository<T> : IBaseRepository<T>
        where T : class
    {
        private readonly WebApiDbContext context;

        public ContentRepository(WebApiDbContext context)
            => this.context = context;

        public async Task Create(T item)
        {
            await context.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            context.Remove(await context.FindAsync<T>(id));
            await context.SaveChangesAsync();
        }

        public async Task Update(T item)
        {
            context.Update(item);
            await context.SaveChangesAsync();
        }

        public void Dispose()
            => context.Dispose();

        public async Task<T> Get(int id)
            => await context.FindAsync<T>(id);

        public IEnumerable<T> GetList()
            => context.Set<T>();

        public async Task SaveAsync()
        => await context.SaveChangesAsync();


    }
}
