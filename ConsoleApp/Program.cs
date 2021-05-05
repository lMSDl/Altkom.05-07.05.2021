using DAL;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //połączenie do bazy w pliku (localdb)
            var contextOptions = new DbContextOptionsBuilder<EFContext>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFC");

            using (var context = new EFContext(contextOptions.Options))
            {
                
            }

            //połączenie do bazy w SqlServer
            using (var context = new EFContext(@"Server=(local);Database=EFC;Integrated Security=true"))
            {

            }
        }
    }
}
