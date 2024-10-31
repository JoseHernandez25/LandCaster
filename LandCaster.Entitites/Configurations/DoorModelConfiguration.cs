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
    public class DoorModelConfiguration : IEntityTypeConfiguration<DoorModel>
    {
        public void Configure(EntityTypeBuilder<DoorModel> builder)
        {
            builder.Property(prop => prop.Id)
                    .UseIdentityColumn();

            builder.Property(prop => prop.PrivateCatalog).HasMaxLength(45)
                .IsRequired();

            builder.Property(prop => prop.PublicCatalog).HasMaxLength(45)
                .IsRequired();

            builder.Property(prop => prop.GolaHandle)  
        .HasDefaultValue(false);
            builder.Property(prop => prop.EditGolaModel)
        .HasDefaultValue(false);


            // Configure many-to-many relationship with Material
            builder.HasMany(d => d.Materials)
                .WithMany(m => m.DoorModels)
                .UsingEntity<Dictionary<string, object>>(
                    "DoorModelMaterial",
                    dm => dm.HasOne<Material>().WithMany().HasForeignKey("MaterialId").OnDelete(DeleteBehavior.Restrict),
                    md => md.HasOne<DoorModel>().WithMany().HasForeignKey("DoorModelId").OnDelete(DeleteBehavior.Restrict));

            builder.HasQueryFilter(prop => prop.DeletedAt == null);


        }
    }
}
