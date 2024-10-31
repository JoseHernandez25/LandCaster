using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();
            builder.Property(prop => prop.Code).IsRequired(false);
            builder.HasIndex(prop => prop.Code).IsUnique();
            builder.Property(prop => prop.Name).HasMaxLength(50).IsRequired(false);
            builder.Property(prop => prop.Status).IsRequired(false);
            builder.Property(prop => prop.Address).IsRequired(false);
            builder.Property(prop => prop.Telephone).IsRequired(false);
            builder.Property(prop => prop.RFC).IsRequired(false);
            builder.Property(prop => prop.CURP).IsRequired(false);
            builder.Property(prop => prop.NSS).IsRequired(false);
            builder.Property(prop => prop.BirthDate).IsRequired(false);

            //// Apply the global query filter
            builder.HasQueryFilter(prop => prop.DeletedAt == null);
            //builder.HasOne(e => e.User).WithOne(e => e.Employee);
        }
    }
}
