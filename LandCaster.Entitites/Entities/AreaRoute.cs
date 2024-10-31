using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    public class AreaRoute
    {
        [Key]
        public int id { get; set; }

        public int AreaId { get; set; }
        public int RouteId { get; set; }
        public Area Area { get; set; } 

        public Route Route { get; set; } 
        public int Order { get; set; }
        public double Percent { get; set; }
    }
}
