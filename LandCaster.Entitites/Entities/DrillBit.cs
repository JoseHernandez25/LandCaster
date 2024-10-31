using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(DrillBitConfiguration))]
    public class DrillBit: TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Path { get; set; }
        public ICollection<DoorModel> DoorModels { get; } = new List<DoorModel>();



    }
}
