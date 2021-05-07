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
            //builder.HasKey(x => new { x.FirstName, x.LastName });

            builder.Property(x => x.PESEL).HasPrecision(11, 0);
            builder.HasAlternateKey(x => x.PESEL);
            //builder.HasAlternateKey(x => new { x.FirstName, x.LastName });

            builder.ToTable("People", "efc");

            builder.Property(x => x.LastName)
                   .HasMaxLength(24)
                   .IsRequired();

            builder.Property(x => x.FirstName)
                   .IsRequired();

            builder.HasIndex(x => new { x.FirstName, x.LastName })
                .HasDatabaseName("Index_FirstLastName")
                .IncludeProperties(x => new { x.BirthDate, x.PESEL });

            builder.Property(x => x.BirthDate)
                .HasPrecision(0);

            builder.HasIndex(x => x.BirthDate)
                .IsUnique()
                //.HasFilter("[BirthDate] IS NOT NULL")
                .HasFilter(null);

            builder.Property(x => x.SomeData)
                //.HasColumnName("DataSome")
                .HasPrecision(10, 5)
                .HasDefaultValue(1000);

            //Shadow Property
            builder.Property<DateTime>("Created")
                .HasDefaultValueSql("getdate()");
            //.ValueGeneratedOnAdd();

            /*builder.Property(x => x.Modified)
                .ValueGeneratedOnAddOrUpdate();*/

            //builder.Ignore(x => x.FullName);
            builder.Property(x => x.FullName).HasComputedColumnSql("[LastName] + ' ' + [FirstName]");


            //builder.Ignore(x => x.Address);
            builder.HasOne(x => x.Address)
                .WithMany(x => x.People)
                .HasForeignKey(x => x.AddressId);

            builder.HasDiscriminator<int>("ClassType")
            //builder.HasDiscriminator(x => x.ClassType)
                .HasValue<Person>(1)
                .HasValue<Student>(2)
                .HasValue<Educator>(3);
                //.IsComplete(false);
        }
    }
}
