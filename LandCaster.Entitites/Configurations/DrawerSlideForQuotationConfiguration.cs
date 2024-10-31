using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LandCaster.Entities.Configurations
{
    public class DrawerSlideForQuotationConfiguration : IEntityTypeConfiguration<DrawerSlideForQuotation>
    {
        public void Configure(EntityTypeBuilder<DrawerSlideForQuotation> builder)
        {
            // Configure many-to-many relationship with DoorModel

            builder.HasOne(dsfq => dsfq.DrawerSlide)
                .WithMany(ds => ds.DrawerSlideForQuotations)
                .HasForeignKey(dsfq => dsfq.DrawerSlideId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dsfq => dsfq.Drawer)
                .WithMany(d => d.DrawerSlideForQuotations)
                .HasForeignKey(dsfq => dsfq.DrawerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dsfq => dsfq.DrawerSlideType)
                .WithMany(dst => dst.CotizationDrawerSlides)
                .HasForeignKey(dsfq => dsfq.DrawerSlideTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
