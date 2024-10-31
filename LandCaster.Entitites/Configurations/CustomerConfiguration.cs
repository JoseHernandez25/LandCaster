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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();

            builder.Property(prop => prop.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prop => prop.Prefix)
                .HasMaxLength(10)
                     .IsRequired();

            builder.Property(prop => prop.Frequency).IsRequired();
            builder.Property(prop => prop.BirthDate).IsRequired(false);
            builder.Property(prop => prop.BirthDate).HasMaxLength(15).IsRequired();
            builder.Property(prop => prop.Rfc).HasMaxLength(20);

            builder.HasQueryFilter(prop => prop.DeletedAt == null);


        }
    }
}
