using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(FinishConfiguration))]
    public class Finish : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal FinishIFDoors { get; set; }
        public decimal FinishIFAcc {  get; set; }

        public ICollection<SubTypeMaterial> SubTypeMaterials { get; } = new List<SubTypeMaterial>();
    }
}
