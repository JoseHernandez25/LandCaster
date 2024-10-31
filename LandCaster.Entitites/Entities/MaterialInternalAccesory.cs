using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    public class MaterialInternalAccessory
    {
        [Key]
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int InternalAccessoryId { get; set; }
        public double Cost { get; set; }
        public Material Material { get; set; }
        public InternalAccessory InternalAccessory { get; set; }
    }
}
