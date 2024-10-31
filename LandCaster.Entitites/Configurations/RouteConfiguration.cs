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
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();

            builder.Property(prop => prop.Code)
                .IsRequired();
            builder.Property(prop => prop.Type)
                .IsRequired();

            builder.HasQueryFilter(prop => prop.DeletedAt == null);
        }
    }
}
