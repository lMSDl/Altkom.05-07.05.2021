using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //builder.HasKey(x => x.Identifier);

            builder.ToTable("People", "efc");

            builder.Property(x => x.LastName)
                   .HasMaxLength(24)
                   .IsRequired();

            builder.Property(x => x.FirstName)
                   .IsRequired();

            builder.Property(x => x.BirthDate)
                .HasPrecision(0);

            builder.Property(x => x.SomeData)
                .HasPrecision(10, 5);


            builder.Ignore(x => x.Address);
        }
    }
}
