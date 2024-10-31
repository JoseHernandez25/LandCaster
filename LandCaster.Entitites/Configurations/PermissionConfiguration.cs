using LandCaster.Entitites.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(prop => prop.Name)
                .HasMaxLength(20)
                .IsRequired();
            builder.HasIndex(prop => prop.Name).IsUnique();

            builder.Property(prop => prop.Alias)
            .HasMaxLength(100)
                .IsRequired();


            // Specify the order of the columns

            //// Apply the global query filter
            builder.HasQueryFilter(prop => prop.DeletedAt == null);
        }
    }
}
