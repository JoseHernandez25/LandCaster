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
    public class StructureConfiguration : IEntityTypeConfiguration<Structure>
    {
        public void Configure(EntityTypeBuilder<Structure> builder)
        {
            builder.HasIndex(prop => prop.Code).IsUnique();
            builder.HasIndex(prop => prop.NewCode).IsUnique();

            builder.HasQueryFilter(prop => prop.DeletedAt == null);

            //builder.HasOne(e => e.User).WithOne(e => e.Stores);

        }
    }
}
