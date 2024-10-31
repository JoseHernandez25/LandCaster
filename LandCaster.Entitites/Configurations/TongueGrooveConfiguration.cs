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
    public class TongueGrooveConfiguration : IEntityTypeConfiguration<TongueGroove>
    {
            public void Configure(EntityTypeBuilder<TongueGroove> builder)
            {
                builder.Property(prop => prop.Id)
                        .UseIdentityColumn();

                builder.Property(prop => prop.Code)
                    .HasMaxLength(100)
                    .IsRequired();


                builder.Property(prop => prop.Name).HasMaxLength(150)
                .IsRequired();

                builder.HasQueryFilter(prop => prop.DeletedAt == null);

                builder.Property(prop => prop.Path).HasMaxLength(500).IsUnicode(false);
            }
        

    }
}
