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
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.Property(prop => prop.Id)
                    .UseIdentityColumn();

            builder.Property(prop => prop.Name).HasMaxLength(45)
            .IsRequired();

            builder.Property(prop => prop.Description).HasMaxLength(45)
            .IsRequired();

            builder.Property(prop => prop.WeightPerM2).HasMaxLength(45)
            .IsRequired(false);

            //builder.Property(prop => prop.HaBarniz)
            //.IsRequired();

            // Configure many-to-many relationship with DoorModel
            builder.HasMany(m => m.DoorModels)
                .WithMany(d => d.Materials)
                .UsingEntity<Dictionary<string, object>>(
                    "DoorModelMaterial",
                    dm => dm.HasOne<DoorModel>().WithMany().HasForeignKey("DoorModelId").OnDelete(DeleteBehavior.Restrict),
                    md => md.HasOne<Material>().WithMany().HasForeignKey("MaterialId").OnDelete(DeleteBehavior.Restrict));



            builder.HasQueryFilter(prop => prop.DeletedAt == null);

        }
    }
}
