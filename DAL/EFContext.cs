using Microsoft.EntityFrameworkCore;
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
    }
}
