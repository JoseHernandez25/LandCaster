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
    public class MaterialTypeConfiguration : IEntityTypeConfiguration<MaterialType>
    {
        public void Configure(EntityTypeBuilder<MaterialType> builder)
        {
            builder.Property(prop => prop.Id)
                    .UseIdentityColumn();

            builder.Property(prop => prop.Name).HasMaxLength(45)
            .IsRequired();

            builder.Property(prop => prop.HasBarniz)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasQueryFilter(prop => prop.DeletedAt == null);

        }
    }
}
