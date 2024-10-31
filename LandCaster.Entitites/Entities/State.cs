using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(StateConfiguration))]
    public class State : TimeStamp
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        //Relations
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
        public ICollection<City> Cities { get; } = new List<City>();
    }
}
