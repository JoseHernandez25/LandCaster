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
    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();
            builder.Property(prop => prop.Name).HasMaxLength(100)
                .IsRequired();
            builder.Property(prop => prop.Code).HasMaxLength(50)
                .IsRequired();
            builder.Property(prop => prop.Creditor).HasMaxLength(50)
                .IsRequired();
            builder.Property(prop => prop.Website).HasMaxLength(80);
            builder.Property(prop => prop.Representative).HasMaxLength(100);
            builder.Property(prop => prop.Account).HasMaxLength(25);

            builder.HasQueryFilter(prop => prop.DeletedAt == null);
        }
    }
}
