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
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();
            //// Apply the global query filter
            builder.Property(prop => prop.Name).HasMaxLength(50)
                .IsRequired();
            builder.Property(prop => prop.Value).HasMaxLength(10)
                .IsRequired();
            builder.HasQueryFilter(prop => prop.DeletedAt == null);
        }
    }
}
