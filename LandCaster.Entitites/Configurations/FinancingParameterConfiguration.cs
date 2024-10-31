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
    public  class FinancingParameterConfiguration : IEntityTypeConfiguration<FinancingParameter>
    {
        public void Configure(EntityTypeBuilder<FinancingParameter> builder)
        {
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();
            builder.HasIndex(prop => prop.Name).IsUnique();

            builder.HasQueryFilter(prop => prop.DeletedAt == null);
        }
    }
}
