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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasMany(x => x.People).WithOne(x => x.Address).HasForeignKey(x => x.AddressId);

            builder.HasMany(x => x.Companies).WithMany(x => x.Addresses);
        }
    }
}
