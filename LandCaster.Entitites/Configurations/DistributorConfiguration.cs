using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace LandCaster.Entities.Configurations
{
    public class DistributorConfiguration : IEntityTypeConfiguration<Distributor>
    {
        public void Configure(EntityTypeBuilder<Distributor> builder)
        {
            builder.Property(prop => prop.Id)
                .UseIdentityColumn();
            builder.HasQueryFilter(prop => prop.DeletedAt == null);
        }
    }
}
