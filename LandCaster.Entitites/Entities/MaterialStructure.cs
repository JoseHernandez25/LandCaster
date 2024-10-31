using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    public class MaterialStructure
    {
        [Key]
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int StructureId { get; set; }
        public double Cost { get; set; }

        public Material Material { get; set; }
        public Structure Structure { get; set; }

    }
}
