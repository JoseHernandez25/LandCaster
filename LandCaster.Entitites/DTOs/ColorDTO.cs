using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs
{
    public class ColorDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? SupplierCode { get; set; }
        public string? Description { get; set; }

        public ICollection<SubTypeMaterial> SubTypeMaterials { get; } = new List<SubTypeMaterial>();

    }
}
