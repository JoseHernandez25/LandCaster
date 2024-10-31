using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs.Discounts
{
    public class AddVolumeRangeDTO
    {
        public VolumeRange VolumeRange { get; set; }

        public int[] DiscountTypesIds { get; set; }
    }
}
