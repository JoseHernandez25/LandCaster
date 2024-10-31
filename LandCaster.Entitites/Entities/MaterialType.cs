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
    [EntityTypeConfiguration(typeof(MaterialTypeConfiguration))]
    public class MaterialType : TimeStamp
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool HasBarniz { get; set; }
        public ICollection<Material> Materials { get; } = new List<Material>();

        public ICollection<Color> colors { get; } = new List<Color>();
        public ICollection<SubTypeMaterial> SubTypeMaterials { get; } = new List<SubTypeMaterial>();

 
    }
}
