using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPeopleService : IService<Person>
    {
        Task<Person> FindByPesel(decimal pesel);
    }
}
