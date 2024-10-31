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
    public class HingeTypeConfiguration : IEntityTypeConfiguration<HingeType>
    {
        public void Configure(EntityTypeBuilder<HingeType> builder)
        {
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();
            //// Apply the global query filter
            builder.Property(prop => prop.Name).HasMaxLength(30)
                .IsRequired();
            builder.HasQueryFilter(prop => prop.DeletedAt == null);

        }
    }
}
