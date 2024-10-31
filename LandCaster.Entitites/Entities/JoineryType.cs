using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(JoinerieTypeConfiguration))]
    public class JoineryType : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }



        public ICollection<Joinery> Joineries { get; } = new List<Joinery>();

        public ICollection<DoorModel> DoorModel { get; } = new List<DoorModel>();
    }
}
