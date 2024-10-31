using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs
{
    public class AddTypesBoxJourneyDTO
    {
        public TypesBoxJourney TypesBoxJourney { get; set; }
        public int[] DoorModelIds { get; set; }
    }
}
