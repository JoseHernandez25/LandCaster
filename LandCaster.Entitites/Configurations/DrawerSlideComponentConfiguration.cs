using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Configurations
{
    public class DrawerSlideComponentConfiguration : IEntityTypeConfiguration<DrawerSlideComponent>
    {
        public void Configure(EntityTypeBuilder<DrawerSlideComponent> builder)
        {
            builder.Property(prop => prop.Id)
                    .UseIdentityColumn();
            //// Apply the global query filter
            builder.Property(prop => prop.SupplierCode).HasMaxLength(100)
                .IsRequired();
            builder.Property(prop => prop.Name).HasMaxLength(100)
                .IsRequired();
            builder.Property(prop => prop.Cost).HasColumnType("Decimal")
                .IsRequired();
            builder.HasQueryFilter(prop => prop.DeletedAt == null);
            builder.HasOne(c => c.Brand)
       .WithMany(b => b.DrawerSlidesComponents) // Asegúrate de que estás usando la propiedad correcta de navegación
       .HasForeignKey(c => c.BrandId) // Especifica explícitamente la propiedad BrandId como clave externa
       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
