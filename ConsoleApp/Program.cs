using DAL;
using DAL.Services;
using DAL2.Models;
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
                context.Database.Migrate();
                await new PeopleService(context).ReadAsync();
            }

            //połączenie do bazy w SqlServer
            using (var context = new EFCContext())
            {
                //context.Database.Migrate();
                var result = context.Set<DAL2.Models.Person>().ToListAsync(); ;
            }
        }
    }
}
