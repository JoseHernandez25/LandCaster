using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs
{
    public class AddJoineryDTO
    {
        public Joinery Joinery { get; set; }
        public int[] JoineryTypeIds { get; set; }
    }
}
