using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(FurnitureConfiguration))]

    public class Furniture : TimeStamp
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Volume { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Depth { get; set; }
       
        public string SpecialNomenclature { get; set; }
        public string FirstNomenclature { get; set; }
        public string SecondNomenclature { get; set; }        

        public bool StaticHeight { get; set; }
        [Required]
        public bool StaticWidth { get; set; }
        [Required]
        public bool StaticDepth { get; set; }
        public string IntegralFinish { get; set; }
        public string CatalogNumber { get; set; }
        public string Type { get; set; }
        public double Clearance { get; set; }
        [Required]
        public int CodeHeight { get; set; }
        [Required]
        public int CodeWidth { get; set; }
        [Required]
        public int CodeDepth { get; set; }
        [Required]
        public double InstalationCost { get; set; }
        [Required]
        public double PackagingCosts { get; set; }
        [Required]
        public int Shelves { get; set; }
        [Required]
        public int Tops { get; set; }
        public string Clasification { get; set; }
        public int Screws { get; set; }
        [Required]
        public int NumberOfLegs { get; set; }
        [Required]
        public int DrawerPulls { get; set; }
        [Required]
        public int DoorsPulls { get; set; }
        [Required]
        public bool HasLegs { get; set; }  
        [Required]
        public bool HasSquareMeters { get; set; }
        [Required]
        public bool HasLinearMeters { get; set; }

        //Relaciones
        public List<FurnitureAccessory> FurnitureAccessories { get; } = new();
        public List<FurnitureExternalAccessory> FurnitureExternalAccessories { get; } = new();

        public List<LandCasterProduct> LandCasterProducts { get; } = new();
        public List<FurnitureDrawer> FurnitureDrawers { get; } = new();

        public List<HingesForQuotation> HingesForQuotations { get; } = new();
        public List<FurnitureStructure> FurnitureStructures { get; } = new();



    }
}
