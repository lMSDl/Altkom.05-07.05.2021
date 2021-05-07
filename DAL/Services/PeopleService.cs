using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class PeopleService : Service<Person>, IPeopleService
    {
        public PeopleService(DbContext context) : base(context)
        {
        }

        public async Task<Person> FindByPesel(decimal pesel)
        {

            var result = await _context.Set<Person>().Select(x => new Person() { Id = x.Id, PESEL = x.PESEL, LastName = x.LastName, BirthDate = x.BirthDate }).SingleOrDefaultAsync(x => x.PESEL == pesel);

            //return new Person() { PESEL = result.PESEL, LastName = result.LastName, BirthDate = result.BirthDate };
            return result;
        }

        public override async Task<Person> ReadAsync(int id)
        {
            var result = await _context.Set<Person>().FromSqlInterpolated($"EXEC efc.GetPerson {id}").ToListAsync();
            return result.SingleOrDefault();
        }

        public override async Task<IEnumerable<Person>> ReadAsync()
        {
            return await _context.Set<Person>().FromSqlRaw("EXEC efc.GetPeople").ToListAsync();
        }
    }
}
