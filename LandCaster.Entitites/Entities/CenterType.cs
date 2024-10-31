using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(CenterTypeConfiguration))]
    public class CenterType : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<DoorModel> DoorModels { get; } = new List<DoorModel>();
    }
}
