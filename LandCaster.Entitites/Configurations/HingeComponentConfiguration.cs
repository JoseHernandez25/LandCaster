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
    public class HingeComponentConfiguration: IEntityTypeConfiguration<HingeComponent>
    {
        public void Configure(EntityTypeBuilder<HingeComponent> builder)
        {
            builder.Property(prop => prop.Id)
                    .UseIdentityColumn();
            //// Apply the global query filter
            builder.Property(prop => prop.Code).HasMaxLength(100)
                .IsRequired();
            builder.Property(prop => prop.Name).HasMaxLength(100)
                .IsRequired();
            builder.Property(prop => prop.Price).HasColumnType("Decimal")
                .IsRequired();

            builder.Property(prop => prop.BrandId)
        .IsRequired(false);

            builder.HasQueryFilter(prop => prop.DeletedAt == null);

            builder.HasOne(c => c.Brand)
       .WithMany(b => b.HingeComponents) // Asegúrate de que estás usando la propiedad correcta de navegación
       .HasForeignKey(c => c.BrandId) // Especifica explícitamente la propiedad BrandId como clave externa
       .OnDelete(DeleteBehavior.Restrict).IsRequired(false);


        }
    }
}
