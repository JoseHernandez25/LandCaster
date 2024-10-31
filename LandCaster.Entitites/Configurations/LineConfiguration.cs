using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LandCaster.Entities.Configurations
{
    public class LineConfiguration : IEntityTypeConfiguration<Line>
    {
        public void Configure(EntityTypeBuilder<Line> builder)
        {
            builder.Property(prop => prop.Id)
                    .UseIdentityColumn();

            builder.Property(prop => prop.Name).HasMaxLength(45)
                .IsRequired();

            builder.Property(prop => prop.Description).HasMaxLength(150)
                .IsRequired(false);

            builder.HasQueryFilter(prop => prop.DeletedAt == null);
        }
    }
}
