using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs.DoorsModels
{
    public class DoorModelDTO
    {
        public int Id { get; set; }
        public string? PrivateCatalog { get; set; }
        public string? PublicCatalog { get; set; }
        public int ModelId { get; set; }
        public int JoineryId { get; set; }
        public int JoineryTypeId { get; set; }
        public int LineId { get; set; }
        public int RouteId { get; set; }
        public int MaterialTypeId { get; set; }
    }
}
