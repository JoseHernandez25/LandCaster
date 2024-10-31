using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Configurations
{
    public class VolumeRangeConfiguration : IEntityTypeConfiguration<VolumeRange>
    {
        public void Configure(EntityTypeBuilder<VolumeRange> builder)
        {
            {
                builder.Property(prop => prop.Id)
                        .UseIdentityColumn();

                builder.Property(prop => prop.StartRange)
                        .IsRequired();

                builder.Property(prop => prop.EndRange)
                        .IsRequired();

                builder.Property(prop => prop.DiscountType)
                  .HasConversion<int>()
                  .IsRequired();

                builder.HasQueryFilter(prop => prop.DeletedAt == null);
            }
        }
    }
}