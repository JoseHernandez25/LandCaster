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
    [EntityTypeConfiguration(typeof(StructureConfiguration))]

    public class Structure:TimeStamp
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string NewCode { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public int? StructureTypeId { get; set; }

        public StructureType StructureType { get; set; } = null!;
        public List<FurnitureStructure> FurnitureStructures { get; } = new();
        public List<MaterialStructure> MaterialStructures { get; } = new();

    }
}
