using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(InsertConfiguration))]
    public class Insert : TimeStamp
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double height { get; set; }
        public double width { get; set; }
        public string? Image { get; set; }

        public List<DoorModelInsert> DoorModelInserts { get; } = new();
    }
}
