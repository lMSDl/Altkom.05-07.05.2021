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
    public class Service<T> : IService<T> where T : Entity
    {
        protected DbContext _context;

        public Service(DbContext context)
        {
            _context = context;
        }

        public int Create(T entity)
        {
            return CreateAsync(entity).Result;
        }

        public async Task<int> CreateAsync(T entity)
        {
            entity.Id = 0;
            var entry = _context.Add(entity);

            _context.ChangeTracker.DetectChanges();
            Console.WriteLine(_context.ChangeTracker.DebugView.LongView);

            await _context.SaveChangesAsync();
            return entry.Entity.Id;
        }

        public void Delete(int id)
        {
            DeleteAsync(id).RunSynchronously();
        }

        public virtual async Task DeleteAsync(int id)
        {
            //var entity = _context.Set<Person>().Find(id);
            //_context.Set<Person>().Remove(entity);
            _context.Remove(await ReadAsync(id));

            _context.ChangeTracker.DetectChanges();
            Console.WriteLine(_context.ChangeTracker.DebugView.LongView);

            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> ReadAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> Read()
        {
            return ReadAsync().Result;
        }

        public T Read(int id)
        {
            return ReadAsync(id).Result;
        }

        public virtual async Task<T> ReadAsync(int id)
        {
            //return await _context.Set<T>().FindAsync(id);
            return await _context.FindAsync<T>(id);
            //return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Update(int id, T entity)
        {
            UpdateAsync(id, entity).RunSynchronously();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            entity.Id = id;

            _context.Set<T>().Local.Remove(_context.Set<T>().Local.SingleOrDefault(x => x.Id == id));
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            //_context.Update(entity);


            if (entity is Person)
            {
                _context.Entry(entity).Property("LastName").IsModified = false;
            }

            //_context.ChangeTracker.DetectChanges();
            //Console.WriteLine(_context.ChangeTracker.DebugView.LongView);
            await _context.SaveChangesAsync();
        }
    }
}
