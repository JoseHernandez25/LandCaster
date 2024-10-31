using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Configurations
{
    public class InternalAccessoryConfiguration : IEntityTypeConfiguration<InternalAccessory>
    {
        public void Configure(EntityTypeBuilder<InternalAccessory> builder)
        {
            builder.Property(prop => prop.Id)
                    .UseIdentityColumn();

            builder.Property(prop => prop.Code).HasMaxLength(45)
            .IsRequired();

            builder.Property(prop => prop.Name).HasMaxLength(45)
            .IsRequired();

            builder.Property(prop => prop.Description).HasMaxLength(45)
            .IsRequired(false);

            builder.Property(prop => prop.height).HasMaxLength(45)
            .IsRequired();

            builder.Property(prop => prop.width).HasMaxLength(45)
           .IsRequired();

            builder.Property(prop => prop.depth).HasMaxLength(45)
           .IsRequired();

            builder.Property(prop => prop.VarnishSquareMeters).HasMaxLength(45)
            .IsRequired(false);

            builder.Property(prop => prop.FirstNomenclature).HasMaxLength(45)
            .IsRequired(false);

            builder.Property(prop => prop.SecondNomenclature).HasMaxLength(100)
            .IsRequired(false);

            builder.Property(prop => prop.ThirdNomenclature).HasMaxLength(100)
            .IsRequired(false);

            builder.HasQueryFilter(prop => prop.DeletedAt == null);

        }
    }
}
