using LandCaster.Entities.Entities;
using LandCaster.Entities.Entities.Catalogs;
using LandCaster.Entitites.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Configurations.Catalogs
{
    public class AccessoryConfig
    {
        public void Configure(EntityTypeBuilder<Accessory> builder)
        {
            builder.Property(prop => prop.Name)
                .HasMaxLength(20)
                .IsRequired();
            builder.HasIndex(prop => prop.Name).IsUnique();

            builder.Property(prop => prop.Description)
            .HasMaxLength(100)
                .IsRequired();

        }
    }
}
