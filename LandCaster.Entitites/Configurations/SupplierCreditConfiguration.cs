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
    public class SupplierCreditConfiguration : IEntityTypeConfiguration<SupplierCredit>
    {
        public void Configure(EntityTypeBuilder<SupplierCredit> builder)
        {
            builder.Property(prop => prop.Id)
                .IsRequired();
            builder.Property(prop => prop.Description).HasMaxLength(100)
               .IsRequired();

            builder.HasQueryFilter(prop => prop.DeletedAt == null);


        }
    
    }
}
