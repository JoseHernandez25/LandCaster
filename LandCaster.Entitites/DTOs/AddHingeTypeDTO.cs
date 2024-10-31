using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs
{
    public class AddHingeTypeDTO
    {
        public int BrandId { get; set; }
        public Hinge[] Hinges { get; set; }
        public string Name { get; set; }

    }
}
