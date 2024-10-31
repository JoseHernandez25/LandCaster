using LandCaster.Entities.DTOs.DoorsModels;
using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs.DoorsModels
{
    public class UpdateDoorModelDTO
    {
        public DoorModel DoorModel { get; set; }
        public int[] TypesBoxJourneyIds { get; set; }
        public int[] MaterialIds { get; set; }
        public int[] DoorTypeIds { get; set; }

    }
}
