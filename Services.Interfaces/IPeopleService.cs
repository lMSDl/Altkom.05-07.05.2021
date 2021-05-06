using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPeopleService
    {
        Task<int> CreateAsync(Person person);
        int Create(Person person);
        Task<IEnumerable<Person>> ReadAsync();
        IEnumerable<Person> Read();
        Task<Person> ReadAsync(int id);
        Person Read(int id);
        Task UpdateAsync(int id, Person person);
        void Update(int id, Person person);
        Task DeleteAsync(int id);
        void Delete(int id);
    }
}
