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
    public class ProductEventDetailConfiguration : IEntityTypeConfiguration<ProductEventDetail>
    {
        public void Configure(EntityTypeBuilder<ProductEventDetail> builder)
        {
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();
            builder.Property(prop => prop.Quantity)
                .IsRequired();
            builder.Property(prop => prop.Cost)
                .IsRequired();
            builder.Property(prop => prop.Price)
                .IsRequired();
            builder.HasQueryFilter(prop => prop.DeletedAt == null);
        }
    }
}
