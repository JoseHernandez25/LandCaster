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
    [EntityTypeConfiguration(typeof(RouteConfiguration))]

    public class Route : TimeStamp
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
      
        public string Description { get; set; }
        [Required]
        public RouteType Type { get; set; }


        public List<AreaRoute> AreasRoutes { get; set; }

        public enum RouteType
        {
            Puertas = 1,
            Abrillantados = 2,
            PuertasIntercomunicacion = 3,

        }
    }
}
