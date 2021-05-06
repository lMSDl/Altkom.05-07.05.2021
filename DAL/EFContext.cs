using DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EFContext : DbContext
    {
        private readonly string _connectionString;

        //public DbSet<Person> People { get; set; } 

        public EFContext()
        {
        }

        //public EFContext(DbContextOptions options) : base(options)
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        public EFContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if(!optionsBuilder.IsConfigured)
            {
                if(!string.IsNullOrWhiteSpace(_connectionString))
                    optionsBuilder.UseSqlServer(_connectionString);
#if DEBUG
                else
                    optionsBuilder.UseSqlServer(@"Server=(local);Database=EFC;Integrated Security=true");
#endif
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>();
            /* modelBuilder.Entity<Person>()
                 .Property(x => x.LastName)
                 .HasMaxLength(24)
                 .IsRequired();*/

            //new PersonConfiguration().Configure(modelBuilder.Entity<Person>());
            //modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonConfiguration).Assembly);

            //modelBuilder.Ignore<Address>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
