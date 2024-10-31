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
    public class AngleConfiguration : IEntityTypeConfiguration<Angle>
    {
        public void Configure(EntityTypeBuilder<Angle> builder)
        {
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();
            builder.Property(prop => prop.Name).HasMaxLength(45)
                .IsRequired();

            builder.Property(prop => prop.Value).IsRequired(false);
            builder.HasQueryFilter(prop => prop.DeletedAt == null);


        }
    }
 }

