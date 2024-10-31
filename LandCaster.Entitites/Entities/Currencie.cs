using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(CurrencieConfiguration))]
    public class Currencie : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Iso { get; set; }
        public double CurrentValue { get; set; }
        public string Symbol { get; set; }

        //Relations
        public ICollection<DrawerSlideComponent> DrawerSlidesComponents { get; } = new List<DrawerSlideComponent>();
        public ICollection<HingeComponent> hingeComponents { get; } = new List<HingeComponent>();
        public ICollection<ExternalAccessory> ExternalAccessory { get; } = new List<ExternalAccessory>();
    }
}
