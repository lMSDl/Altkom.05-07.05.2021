﻿using DAL;
using DAL.Services;
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
                await new PeopleService(context).ReadAsync();
            }

            //połączenie do bazy w SqlServer
            using (var context = new EFContext(@"Server=(local);Database=EFC;Integrated Security=true"))
            {
                await new Service<Address>(context).ReadAsync();
            }
        }
    }
}
