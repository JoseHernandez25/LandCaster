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
    public class InsertConfiguration : IEntityTypeConfiguration<Insert>
    {
        public void Configure(EntityTypeBuilder<Insert> builder)
        {
            builder.Property(prop => prop.Id)
                   .UseIdentityColumn();

            builder.HasIndex(prop => prop.Code).IsUnique();

            builder.Property(prop => prop.Name).HasMaxLength(150)
            .IsRequired();

            builder.HasQueryFilter(prop => prop.DeletedAt == null);

            builder.Property(prop => prop.Image).HasMaxLength(500).IsUnicode(false);
        }
    }
}
