using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(DrawerSlideForQuotationConfiguration))]

    public class DrawerSlideForQuotation
    {
        [Key]
        public int Id { get; set; }
        public int DrawerSlideId { get; set; }
        public int DrawerId { get; set; }
        public int DrawerSlideTypeId { get; set; }

        public DrawerSlide DrawerSlide { get; set; }
        public DrawerSlideType DrawerSlideType { get; set; }
        public Drawer Drawer { get; set; }
    }
}
