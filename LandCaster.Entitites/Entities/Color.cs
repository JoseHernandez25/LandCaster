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
    [EntityTypeConfiguration(typeof(ColorConfiguration))]
    public class Color : TimeStamp
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string? SupplierCode { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        [Required]
        public int? BrandId { get; set; }
        [Required]
        public bool ForDoors { get; set; } = true;
        [Required]
        public bool ForStructure { get; set; } = true;
        [Required]
        public int? MaterialTypeId { get; set; }
        public Brand Brand { get; set; }
        public MaterialType MaterialType { get; set; }
        public ICollection<SubTypeMaterial> SubTypeMaterials { get; } = new List<SubTypeMaterial>();


    }
}
