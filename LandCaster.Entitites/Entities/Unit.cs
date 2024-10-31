using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(UnitConfiguration))]
    public class Unit : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Abbreviation { get; set; }
        public int UnitType { get; set; }


        //Relations
        public ICollection<DrawerSlideComponent> DrawerSlidesComponents { get; } = new List<DrawerSlideComponent>();
    }
}
