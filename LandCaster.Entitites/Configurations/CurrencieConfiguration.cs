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
    internal class CurrencieConfiguration: IEntityTypeConfiguration<Currencie>
    {
        public void Configure(EntityTypeBuilder<Currencie> builder)
        {
            builder.Property(prop => prop.Id)
                    .UseIdentityColumn();
            //// Apply the global query filter
            builder.Property(prop => prop.Name).HasMaxLength(30)
                .IsRequired();
            builder.Property(prop => prop.Iso).HasMaxLength(45)
              .IsRequired(false);
            builder.Property(prop => prop.CurrentValue).HasColumnType("Decimal")
              .IsRequired();
            builder.Property(prop => prop.Symbol).HasMaxLength(2)
              .IsRequired();
            builder.HasQueryFilter(prop => prop.DeletedAt == null);
        }
    }
}

