using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(ExternalAccessoryConfiguration))]
    public class ExternalAccessory : TimeStamp
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? SupplierKey { get; set; }
        public double Cost { get; set; }
        public double? IncreaseFactor { get; set; }


        //Relations
        public int? CurrencieId { get; set; }
        public Currencie Currencie { get; set; } = null!;
        public int? BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        public int? AccesorieTypeId { get; set; }
        public AccessoryType AccesorieType { get; set; } = null!;
        public int? FinancingParameterId { get; set; }
        public FinancingParameter FinancingParameter { get; set; } = null!;
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<FurnitureExternalAccessory> FurnitureExternalAccessories { get; } = new();

    }

}
