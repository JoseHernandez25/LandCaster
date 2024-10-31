using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs
{
    public class AddSubTypeMaterialDTO
    {
        public SubTypeMaterial SubTypeMaterial { get; set; }
        public int[] MaterialTypeIds { get; set; }
    }

}
