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
    public class PaymentTypeConfiguration : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.Property(prop => prop.Id)
                    .UseIdentityColumn();
            //// Apply the global query filter
            builder.Property(prop => prop.Code)
            .IsRequired();
            builder.Property(prop => prop.Name).HasMaxLength(150)
            .IsRequired();
            builder.Property(prop => prop.FurnitureDiscount)
            .IsRequired();
            builder.Property(prop => prop.CoveredDiscount)
            .IsRequired();
            builder.Property(prop => prop.EquipmentDiscount)
            .IsRequired();
            builder.Property(prop => prop.CashAdvance).HasColumnType("Decimal");
            builder.Property(prop => prop.Clearance).HasColumnType("Decimal");
            builder.Property(prop => prop.Active)
            .IsRequired(false).HasDefaultValue(true); 
            builder.Property(prop => prop.Description).HasMaxLength(150)
          .IsRequired();
            builder.Property(prop => prop.EspFurnitureDiscount)
          .IsRequired();
            builder.Property(prop => prop.EspCoveredDiscount)
            .IsRequired();
            builder.Property(prop => prop.EspEquipmentDiscount)
            .IsRequired();
            builder.Property(prop => prop.ActiveDistribuitor)
            .IsRequired(false).HasDefaultValue(true);
            builder.Property(prop => prop.ActiveSeason)
            .IsRequired(false).HasDefaultValue(true);
            builder.Property(prop => prop.ActiveVolume)
            .IsRequired(false).HasDefaultValue(true);
            builder.HasQueryFilter(prop => prop.DeletedAt == null);
            
        }
    }
}
