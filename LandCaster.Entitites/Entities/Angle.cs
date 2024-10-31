using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(AngleConfiguration))]
    public class Angle : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Value { get; set; }
        //Relations
        public ICollection<Hinge> Hinges { get; } = new List<Hinge>();
    }
}
