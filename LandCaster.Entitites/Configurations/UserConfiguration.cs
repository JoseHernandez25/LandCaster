using LandCaster.Entities.Entities;
using LandCaster.Entitites.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LandCaster.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.HasKey(prop => prop.Id);
            //builder.Property(prop => prop.Id)
            //       .ValueGeneratedOnAdd()  // This will configure the property to be autoincrementable
            //       .UseIdentityColumn();

            builder.Property(prop => prop.ProfilePhoto).HasMaxLength(500).IsUnicode(false);

            // Configure the relationship with Role
            //builder.HasOne(u => u.Role)  // User has one Role
            //       .WithMany(r => r.)  // Role has many Users
            //       .HasForeignKey(u => u.RoleId);  // Foreign key property in User

            //// Apply the global query filter
            ///

            builder.HasQueryFilter(prop => prop.DeletedAt == null);
        }

    }


}