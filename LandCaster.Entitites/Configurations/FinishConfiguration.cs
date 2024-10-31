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
    public class FinishConfiguration : IEntityTypeConfiguration<Finish>
    {
        public void Configure(EntityTypeBuilder<Finish> builder)
        {
            builder.Property(prop => prop.Id)
                    .UseIdentityColumn();

            builder.Property(prop => prop.Name).HasMaxLength(50)
            .IsRequired();

            

            //builder.Property(prop => prop.CostPerLliter).HasColumnType("decimal(18, 2)")
              //  .IsRequired();
            builder.HasQueryFilter(prop => prop.DeletedAt == null);


        }
    }
}
