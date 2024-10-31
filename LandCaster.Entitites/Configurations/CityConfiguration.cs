using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;




namespace LandCaster.Entities.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();
            //// Apply the global query filter
            builder.Property(prop => prop.Name).HasMaxLength(50)
                .IsRequired();
            builder.Property(prop => prop.Abbreviation).HasMaxLength(5)
                .IsRequired();
            builder.HasQueryFilter(prop => prop.DeletedAt == null);
            

        }
    }
}
