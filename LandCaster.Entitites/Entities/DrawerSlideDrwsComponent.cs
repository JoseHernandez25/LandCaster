using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    public class DrawerSlideDrwsComponent
    {
        [Key]
        public int Id { get; set; }
        public int DrawerSlideId { get; set; }
        public int ComponentId { get; set; }
        public int Quantity { get; set; }
        public int? ForteId { get; set; }
        public double? MaxWidth { get; set; }
        public DrawerSlide DrawerSlide { get; set; }
        public DrawerSlideComponent Component { get; set; }
    }
}
