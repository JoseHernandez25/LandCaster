using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs.Hinges
{
    public class AddHingeDTO
    {
        public Hinge Hinge { get; set; }
        public HingeHingeComponent[] Components { get; set; }
    }
}

