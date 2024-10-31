using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(InternalAccessoryConfiguration))]
    public class InternalAccessory : TimeStamp
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string height { get; set; }
        public string width { get; set; }
        public string depth { get; set; }
        public string? VarnishSquareMeters { get; set; }
        public string? FirstNomenclature { get; set; }
        public string? SecondNomenclature { get; set; }
        public string? ThirdNomenclature { get; set; }
        public int InternalAccessoryTypeId { get; set; }

        public List<FurnitureAccessory> FurnitureAccesories { get; } = new();

        public List<MaterialInternalAccessory> MaterialInternalAccesories { get; } = new();
        public InternalAccessoryType InternalAccessoryType { get; set; } = null!;


    }
}
