using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(DrawerSlideTypeConfiguration))]
    public class DrawerSlideType : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSimple { get; set; }


        public ICollection<DrawerSlide> DrawerSlides { get; } = new List<DrawerSlide>();

        public List<DrawerSlideForQuotation> CotizationDrawerSlides { get; } = new();

    }
}
