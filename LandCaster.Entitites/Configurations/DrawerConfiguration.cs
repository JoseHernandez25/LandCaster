using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LandCaster.Entities.Configurations
{
    public class DrawerConfiguration : IEntityTypeConfiguration<Drawer>
    {
        public void Configure(EntityTypeBuilder<Drawer> builder)
        {
            builder.HasIndex(prop => prop.Code).IsUnique();

        }
    }
}
