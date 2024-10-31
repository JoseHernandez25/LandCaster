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
    public class CenterTypeConfiguration : IEntityTypeConfiguration<CenterType>
    {
        public void Configure(EntityTypeBuilder<CenterType> builder)
        {
            builder.Property(prop => prop.Id)
                    .UseIdentityColumn();


            builder.Property(prop => prop.Name).HasMaxLength(150)
            .IsRequired();

            builder.HasQueryFilter(prop => prop.DeletedAt == null);



        }
    }
}
