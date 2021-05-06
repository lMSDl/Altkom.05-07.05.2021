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
    public class EducatorConfiguration : IEntityTypeConfiguration<Educator>
    {
        public void Configure(EntityTypeBuilder<Educator> builder)
        {
            builder.Property(x => x.SchoolName).HasColumnName(nameof(Educator.SchoolName));
        }
    }
}
