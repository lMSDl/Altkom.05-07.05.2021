using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL2.Models
{
    public partial class EFCContext : DbContext
    {
        public EFCContext()
        {
        }

        public EFCContext(DbContextOptions<EFCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressCompany> AddressCompanies { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<LargeCompany> LargeCompanies { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<SmallCompany> SmallCompanies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=EFC;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");
            });

            modelBuilder.Entity<AddressCompany>(entity =>
            {
                entity.HasKey(e => new { e.AddressesId, e.CompaniesId });

                entity.ToTable("AddressCompany");

                entity.HasIndex(e => e.CompaniesId, "IX_AddressCompany_CompaniesId");

                entity.HasOne(d => d.Addresses)
                    .WithMany(p => p.AddressCompanies)
                    .HasForeignKey(d => d.AddressesId);

                entity.HasOne(d => d.Companies)
                    .WithMany(p => p.AddressCompanies)
                    .HasForeignKey(d => d.CompaniesId);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.HasIndex(e => e.OwnerId, "IX_Company_OwnerId")
                    .IsUnique();

                entity.HasOne(d => d.Owner)
                    .WithOne(p => p.Company)
                    .HasForeignKey<Company>(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<LargeCompany>(entity =>
            {
                entity.ToTable("LargeCompany");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.LargeCompany)
                    .HasForeignKey<LargeCompany>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("People", "efc");

                entity.HasIndex(e => e.Pesel, "AK_People_PESEL")
                    .IsUnique();

                entity.HasIndex(e => e.AddressId, "IX_People_AddressId");

                entity.HasIndex(e => e.BirthDate, "IX_People_BirthDate")
                    .IsUnique();

                entity.HasIndex(e => new { e.FirstName, e.LastName }, "Index_FirstLastName");

                entity.Property(e => e.BirthDate).HasPrecision(0);

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(475)
                    .HasComputedColumnSql("(([LastName]+' ')+[FirstName])", false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Modified).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.Pesel)
                    .HasColumnType("decimal(11, 0)")
                    .HasColumnName("PESEL");


                entity.HasOne(d => d.Address)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.AddressId);
            });

            modelBuilder.Entity<SmallCompany>(entity =>
            {
                entity.ToTable("SmallCompany");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.SmallCompany)
                    .HasForeignKey<SmallCompany>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
