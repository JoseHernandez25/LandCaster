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
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();
            //// Apply the global query filter
            builder.Property(prop => prop.Name).HasMaxLength(50)
                .IsRequired();
            builder.Property(prop => prop.Abbreviation).HasMaxLength(5)
                .IsRequired();
            builder.HasQueryFilter(prop => prop.DeletedAt == null);
        }
    }
}
