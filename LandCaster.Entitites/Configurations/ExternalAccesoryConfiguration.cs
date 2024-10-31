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
    public class ExternalAccessoryConfiguration : IEntityTypeConfiguration<ExternalAccessory>
    {
    public void Configure(EntityTypeBuilder<ExternalAccessory> builder)
    {
        builder.Property(prop => prop.Id)
                .UseIdentityColumn();
        //// Apply the global query filter
        builder.Property(prop => prop.Code).HasMaxLength(255)
        .IsRequired();
        builder.Property(prop => prop.Name).HasMaxLength(255)
        .IsRequired();
        builder.Property(prop => prop.Cost).HasColumnType("float")
        .IsRequired();
            builder.Property(prop => prop.IncreaseFactor).HasColumnType("float")
        .IsRequired(false);
            builder.HasQueryFilter(prop => prop.DeletedAt == null);
            builder.Property(prop => prop.SupplierKey).HasMaxLength(100)
        .IsRequired(false);


            builder.HasOne(c => c.Brand)
   .WithMany(b => b.ExternalAccessory) // Asegúrate de que estás usando la propiedad correcta de navegación
   .HasForeignKey(c => c.BrandId) // Especifica explícitamente la propiedad BrandId como clave externa
   .OnDelete(DeleteBehavior.Restrict);
    }
}
}
