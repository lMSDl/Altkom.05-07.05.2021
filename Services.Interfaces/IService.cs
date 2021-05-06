using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IService<T> where T : Entity
    {
        Task<int> CreateAsync(T person);
        int Create(T person);
        Task<IEnumerable<T>> ReadAsync();
        IEnumerable<T> Read();
        Task<T> ReadAsync(int id);
        T Read(int id);
        Task UpdateAsync(int id, T person);
        void Update(int id, T person);
        Task DeleteAsync(int id);
        void Delete(int id);
    }
}
