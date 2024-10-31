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
    public class GlasseConfiguration : IEntityTypeConfiguration<Glasse>
    {
        public void Configure(EntityTypeBuilder<Glasse> builder)
        {
            builder.Property(prop => prop.Id)
                    .UseIdentityColumn();

            builder.Property(prop => prop.Code).HasMaxLength(50)
            .IsRequired();

            builder.Property(prop => prop.Height)
            .IsRequired()
            .HasPrecision(18, 2); // Ajusta los valores de precisión y escala según tus necesidades

            builder.Property(prop => prop.Widht)
            .IsRequired()
            .HasPrecision(18, 2); // Ajusta los valores de precisión y escala según tus necesidades


            builder.HasQueryFilter(prop => prop.DeletedAt == null);
        }
    }
}
