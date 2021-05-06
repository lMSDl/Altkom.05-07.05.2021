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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            //builder.HasMany(x => x.Addresses).WithMany();
            builder.HasOne(x => x.Owner).WithOne(x => x.Company).HasForeignKey<Company>(x => x.OwnerId).IsRequired().OnDelete( DeleteBehavior.NoAction);
        }
    }
}
