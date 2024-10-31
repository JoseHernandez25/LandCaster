using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(DiscountTypeConfiguration))]
    public class DiscountType : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string Type { get; set; }
        public ICollection<VolumeRange> VolumeRanges { get; } = new List<VolumeRange>();


    }
}
