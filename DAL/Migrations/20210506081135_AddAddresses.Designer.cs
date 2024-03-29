﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20210506081135_AddAddresses")]
    partial class AddAddresses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("[LastName] + ' ' + [FirstName]");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PESEL")
                        .HasPrecision(11)
                        .HasColumnType("decimal(11,0)");

                    b.Property<decimal>("SomeData")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(10, 5)
                        .HasColumnType("decimal(10,5)")
                        .HasDefaultValue(1000m);

                    b.HasKey("Id");

                    b.HasAlternateKey("PESEL");

                    b.HasIndex("AddressId");

                    b.HasIndex("BirthDate")
                        .IsUnique();

                    b.HasIndex("FirstName", "LastName")
                        .HasDatabaseName("Index_FirstLastName");

                    b.ToTable("People", "efc");
                });

            modelBuilder.Entity("Models.Person", b =>
                {
                    b.HasOne("Models.Address", null)
                        .WithMany("People")
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Models.Address", b =>
                {
                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}
