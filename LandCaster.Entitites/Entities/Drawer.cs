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
    [EntityTypeConfiguration(typeof(DrawerConfiguration))]

    public class Drawer : TimeStamp
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public string? Description { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }

        public double? Width { get; set; }
        public double? Depth { get; set; }
        public double? DepthLinealMetters { get; set; }

        //Relations
        public List<FurnitureDrawer> FurnitureDrawers { get; } = new();
        public List<DrawerSlideForQuotation> DrawerSlideForQuotations { get; } = new();


    } 
}
