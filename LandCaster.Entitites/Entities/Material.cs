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
    [EntityTypeConfiguration(typeof(MaterialConfiguration))]
    public class Material : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? WeightPerM2 { get; set; }
        public int? SubGroupId { get; set; }
        public int SubTypeMaterialId { get; set; }
        public int MaterialTypeId { get; set; }
        [Required]
        public int MaterialForAccessory { get; set; }


        public MaterialType MaterialType { get; set; } = null!;
        public SubTypeMaterial SubTypeMaterial { get; set; } = null!;

        public ICollection<Glasse> Glasses { get; } = new List<Glasse>();
        public ICollection<DoorModel> DoorModels { get; } = new List<DoorModel>();
        public List<MaterialInternalAccessory> MaterialInternalAccesories { get; } = new();
        public List<MaterialStructure> MaterialStructures { get; } = new();
        public List<GroupMaterial> GroupMaterials { get; } = new();



    }
}
