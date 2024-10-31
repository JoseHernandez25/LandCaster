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
    public class FactoryConfiguration : IEntityTypeConfiguration<Factory>
    {
        public void Configure(EntityTypeBuilder<Factory> builder)
        {
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();
            builder.Property(prop => prop.Code).HasMaxLength(30)
                .IsRequired();
            //// Apply the global query filter
            builder.Property(prop => prop.Name).HasMaxLength(50)
                .IsRequired();
            builder.HasQueryFilter(prop => prop.DeletedAt == null);
        }
    }
}
