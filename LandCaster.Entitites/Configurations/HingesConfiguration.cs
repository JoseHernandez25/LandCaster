using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LandCaster.Entities.Configurations
{
    public class HingesConfiguration : IEntityTypeConfiguration<Hinge>
    {
        public void Configure(EntityTypeBuilder<Hinge> builder)
        {
            // Configure primary key
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();

            // Configure properties
            builder.Property(prop => prop.Code)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prop => prop.Name)
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(prop => prop.BrandId)
                .IsRequired(false);

            builder.Property(prop => prop.Description)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(prop => prop.Observation)
                .HasMaxLength(50)
                .IsRequired(false);

            // Apply the global query filter
            builder.HasQueryFilter(prop => prop.DeletedAt == null);

            // Configure foreign key relationship with Brand
            builder.HasOne(h => h.Brand)
                .WithMany(b => b.Hinges)
                .HasForeignKey(h => h.BrandId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);  // Make BrandId nullable
        }
    }
}
