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
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            // Configure primary key
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();

            builder.Property(prop => prop.Code)
               .HasMaxLength(45)
               .IsRequired();

            builder.Property(prop => prop.Name)
                .HasMaxLength(45)
                .IsRequired();

            

            // Apply the global query filter
            builder.HasQueryFilter(prop => prop.DeletedAt == null);

           
        }
    }
}
