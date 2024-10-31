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
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();   
            builder.Property(prop => prop.Code)
                .HasMaxLength(50)
                .IsRequired();
            builder.HasIndex(prop => prop.Code).IsUnique();
            builder.HasQueryFilter(prop => prop.DeletedAt == null);

            //builder.HasOne(e => e.User).WithOne(e => e.Stores);

        }
    }
}
