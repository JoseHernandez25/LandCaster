using LandCaster.Entities.Entities;
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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(prop => prop.Id).UseIdentityColumn();
            builder.Property(prop => prop.Code).HasMaxLength(45).IsRequired();
            builder.Property(prop => prop.Name).HasMaxLength(45).IsRequired();
            builder.Property(prop => prop.IncreaseFactor).IsRequired(false);
            builder.Property(prop => prop.Description).HasMaxLength(100).IsRequired(false);
            builder.Property(prop => prop.Cost).IsRequired();
            builder.Property(prop => prop.Price).IsRequired();
            builder.HasQueryFilter(prop => prop.DeletedAt == null);

            builder.HasIndex(prop => prop.Code).IsUnique();

        }
    }
}
