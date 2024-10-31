using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs
{
    public class AddJoineryTypeDTO
    {
        public JoineryType JoineryType { get; set; }
        public int[] JoineryIds { get; set; }
    }
}
