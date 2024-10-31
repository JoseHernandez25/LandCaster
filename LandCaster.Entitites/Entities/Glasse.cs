using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(GlasseConfiguration))]
    public class Glasse : TimeStamp
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public double Height { get; set; }
        public double Widht { get; set; }

        public ICollection<Material> Materials { get; } = new List<Material>();
    }
}
