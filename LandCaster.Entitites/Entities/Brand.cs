using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(BrandConfiguration))]
    public class Brand : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Relations
        public ICollection<SubCategory> SubCategories { get; } = new List<SubCategory>();

        public ICollection<DrawerSlideComponent> DrawerSlidesComponents { get; } = new List<DrawerSlideComponent>();
        public ICollection<DrawerSlide> DrawerSlides { get; } = new List<DrawerSlide>();
        public ICollection<Hinge> Hinges { get; } = new List<Hinge>();
        public ICollection<HingeType> hingeTypes { get; } = new List<HingeType>();
        public ICollection<HingeComponent> HingeComponents { get; } = new List<HingeComponent>();
        public ICollection<ExternalAccessory> ExternalAccessory { get; } = new List<ExternalAccessory>();

        public ICollection<Color> Colors { get; } = new List<Color>();



    }
}
