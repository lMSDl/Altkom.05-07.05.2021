using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //połączenie do bazy w pliku (localdb)
            var contextOptions = new DbContextOptionsBuilder<EFContext>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFC");

            using (var context = new EFContext(contextOptions.Options))
            {
                //await context.People.ToListAsync();

               // await context.Set<Person>().ToListAsync();
            }

            //połączenie do bazy w SqlServer
            using (var context = new EFContext(@"Server=(local);Database=EFC;Integrated Security=true"))
            {
                var person = context.Set<Student>().Find(7);
                //person.LastName = "Adamski";
                //context.SaveChanges();
            }
        }
    }
}
