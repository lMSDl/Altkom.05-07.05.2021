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
    public class PeopleService : IPeopleService
    {
        private DbContext _context;

        public PeopleService(DbContext context)
        {
            _context = context;
        }

        public int Create(Person person)
        {
            return CreateAsync(person).Result;
        }

        public async Task<int> CreateAsync(Person person)
        {
            person.Id = 0;
            var entry = _context.Add(person);
            await _context.SaveChangesAsync();
            return entry.Entity.Id;
        }

        public void Delete(int id)
        {
            DeleteAsync(id).RunSynchronously();
        }

        public async Task DeleteAsync(int id)
        {
            //var entity = _context.Set<Person>().Find(id);
            //_context.Set<Person>().Remove(entity);
            _context.Remove(await ReadAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> ReadAsync()
        {
            return await _context.Set<Person>().ToListAsync();
        }

        public IEnumerable<Person> Read()
        {
            return ReadAsync().Result;
        }

        public Person Read(int id)
        {
            return ReadAsync(id).Result;
        }

        public async Task<Person> ReadAsync(int id)
        {
            //return await _context.Set<Person>().FindAsync(id);
            return await _context.FindAsync<Person>(id);
        }

        public void Update(int id, Person person)
        {
            UpdateAsync(id, person).RunSynchronously();
        }

        public async Task UpdateAsync(int id, Person person)
        {
            person.Id = id;
            //_context.Attach(person);
            //_context.Entry(person).State = EntityState.Modified;
            _context.Update(person);
            await _context.SaveChangesAsync();
        }
    }
}
