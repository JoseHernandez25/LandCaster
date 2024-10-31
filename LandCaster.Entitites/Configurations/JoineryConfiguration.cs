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
    public class JoineryConfiguration : IEntityTypeConfiguration<Joinery>
    {
        public void Configure(EntityTypeBuilder<Joinery> builder)
        {
            builder.Property(prop => prop.Id)
                    .UseIdentityColumn();

            builder.Property(prop => prop.Name).HasMaxLength(45)
            .IsRequired();
            builder.HasQueryFilter(prop => prop.DeletedAt == null);

        }
    }
}
