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
    public class DiscountTypeConfiguration : IEntityTypeConfiguration<DiscountType>
    {
        public void Configure(EntityTypeBuilder<DiscountType> builder)
        {
            {

                builder.Property(prop => prop.Id)
                                .UseIdentityColumn();

                // Configure properties
                builder.Property(prop => prop.Name).HasMaxLength(100)
                                .IsRequired();

                builder.Property(prop => prop.Value).HasMaxLength(100)
                                .IsRequired();


                builder.Property(prop => prop.Type)
                          .IsRequired(false);

                builder.HasQueryFilter(prop => prop.DeletedAt == null);


            }
        }
    }
}
