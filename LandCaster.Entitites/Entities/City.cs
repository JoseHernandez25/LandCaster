using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(CityConfiguration))]

    public class City : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        //Relations
        public int StateId { get; set; }
        public State State { get; set; } = null!;
        public ICollection<Factory> Factories { get; } = new List<Factory>();
    }
}
