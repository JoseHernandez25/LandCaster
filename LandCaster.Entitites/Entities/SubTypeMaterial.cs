using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(SubTypeMaterialConfiguration))]
    public class SubTypeMaterial : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }


        //relaciones
        public ICollection<Material> Materials { get; } = new List<Material>();
        public ICollection<Color> Colors { get; } = new List<Color>();
        public ICollection<Finish> Finishes { get; } = new List<Finish>();
        public ICollection<MaterialType> MaterialTypes { get; } = new List<MaterialType>();
        public ICollection<InternalAccessory> InternalAccesories { get; } = new List<InternalAccessory>();

        [NotMapped]
        public ICollection<Finish> FinishesNotIn { get; set; } = new List<Finish>();
    }

}

