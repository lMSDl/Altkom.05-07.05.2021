using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class EFContextService<T> : IService<T> where T : Entity
    {
        protected DbContextOptions<EFContext> _contextOptions;

        public EFContextService(DbContextOptions<EFContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }

        public int Create(T entity)
        {
            return CreateAsync(entity).Result;
        }

        public async Task<int> CreateAsync(T entity)
        {
            using (var context = new EFContext())
            {
                entity.Id = 0;
                var entry = context.Add(entity);
                await context.SaveChangesAsync();
                return entry.Entity.Id;
            }
        }

        public void Delete(int id)
        {
            DeleteAsync(id).RunSynchronously();
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new EFContext())
            {
                var entity = Activator.CreateInstance<T>();
                entity.Id = id;
                context.Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> ReadAsync()
        {
            using (var context = new EFContext())
            {
                return await context.Set<T>().ToListAsync();
            }
        }

        public IEnumerable<T> Read()
        {
            return ReadAsync().Result;
        }

        public T Read(int id)
        {
            return ReadAsync(id).Result;
        }

        public async Task<T> ReadAsync(int id)
        {
            using (var context = new EFContext())
            {
                //return await context.Set<T>().FindAsync(id);
                return await context.FindAsync<T>(id);
                //return await context.Set<T>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            }
        }

        public void Update(int id, T entity)
        {
            UpdateAsync(id, entity).RunSynchronously();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            using (var context = new EFContext())
            {
                entity.Id = id;

                //context.Attach(entity);
                //context.Entry(entity).State = EntityState.Modified;
                context.Update(entity);

                context.ChangeTracker.DetectChanges();
                Console.WriteLine(context.ChangeTracker.DebugView.LongView);

                await context.SaveChangesAsync();
            }
        }
    }
}
