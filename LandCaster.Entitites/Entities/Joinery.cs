using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(JoineryConfiguration))]
   public class Joinery : TimeStamp
    {
        public int Id { get; set; }

        public string Name { get; set; }



        public ICollection<JoineryType> JoineryTypes { get; } = new List<JoineryType>();
        public ICollection<DoorModel> DoorModel { get; } = new List<DoorModel>();
    }
}
