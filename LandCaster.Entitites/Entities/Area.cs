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
    [EntityTypeConfiguration(typeof(AreaConfiguration))]

    public class Area : TimeStamp
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //Relations
        public List<AreaRoute> AreasRoutes { get; set; }

    }
}
