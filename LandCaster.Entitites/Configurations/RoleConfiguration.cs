using LandCaster.Entitites.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(prop => prop.Name)
                .HasMaxLength(20)
                .IsRequired();
            builder.HasIndex(prop => prop.Name).IsUnique();

            //builder.HasMany(r => r.Users) // Role tiene muchos Users
            //   .WithOne(u => u.Role)   // User pertenece a un Role
            //   .HasForeignKey(u => u.RoleId); // Clave foránea en User



            // Apply the global query filter

        }
    }


}
