using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(DoorModelConfiguration))]

    public class DoorModel : TimeStamp
    {
        public int Id { get; set; }
        public string? PrivateCatalog { get; set; }
        public string? PublicCatalog { get; set; }
        public double? WideFrameInH {  get; set; }
        public double? TopFrameWidtInW { get; set; }
        public double? BootomFrameWidthInW { get; set; }
        public double? DoorLeakInH {  get; set; }
        public double? DoorLeakInW { get; set; }
        public double? BoardLeakInH { get; set; }
        public double? BoardLeakInW { get; set; }
        public double? StripPlate {  get; set; }
        public double? PolishedWear { get; set; }
        public double? Dovetail {  get; set; }
        public double? ExteriorTrim { get; set; }
        public bool GolaHandle { get; set; }
        public bool EditGolaModel {  get; set; }
        public int ModelId { get; set; }
        public int JoineryId { get; set; }
        public int JoineryTypeId { get; set; }
        public int LineId { get; set; }
        public int RouteId { get; set; }
        public int MaterialTypeId { get; set; }
        public int? TongueGrooveId { get; set; }
        public int? MoldingId { get; set; }   
        public int? ProfileId { get; set; }
        public int? CenterTypeId { get; set; }

        public MaterialType MaterialType { get; set; } = null!;
        public Line Line { get; set; } = null!;
        public Route Route { get; set; } = null!;
        public Joinery Joinery { get; set; } = null!;
        public JoineryType JoineryType { get; set; } = null!;
        public Model Model { get; set; } = null!;
        public TongueGroove TongueGroove { get; set; } = null!;
        public Molding Molding { get; set; } = null!;
        public Profile Profile { get; set; } = null!;
        public CenterType CenterType { get; set; } = null!;
        public ICollection<TypesBoxJourney> TypesBoxJournies { get; } = new List<TypesBoxJourney>();
        public ICollection<Material> Materials { get; } = new List<Material>();
        public ICollection<DoorType> DoorTypes { get; } = new List<DoorType>();
        public ICollection<DrillBit> DrillBits { get; } = new List<DrillBit>();
        public List<DoorModelInsert> DoorModelInserts { get; } = new();

    }
}
