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
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(prop => prop.Id)
                    .UseIdentityColumn();

            builder.Property(prop => prop.Code).HasMaxLength(150)
            .IsRequired(false);

            builder.Property(prop => prop.Name).HasMaxLength(150)
            .IsRequired();

            builder.Property(prop => prop.ForDoors)
                .IsRequired()
                .HasDefaultValue(true); 

            builder.Property(prop => prop.ForDoors)
                .IsRequired()
                .HasDefaultValue(true);


            builder.Property(prop => prop.SupplierCode).HasMaxLength(150)
            .IsRequired(false);

            builder.Property(prop => prop.Description).HasMaxLength(150)
            .IsRequired(false);

            builder.Property(prop => prop.Image).HasMaxLength(100)
            .IsRequired(false);

            builder.HasQueryFilter(prop => prop.DeletedAt == null);
        }
    }
}
