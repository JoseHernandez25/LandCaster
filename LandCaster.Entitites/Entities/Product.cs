using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(ProductConfiguration))]
    public class Product : TimeStamp
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double? IncreaseFactor { get; set; }
        public string? Description { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int SubSubCategoryId { get; set; }
        public SubSubCategory SubSubCategory { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public int CurrencieId { get; set; }
        public Currencie Currencie { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; } = new List<PurchaseOrderDetail>();
        public ICollection<Inventory> Inventories { get; } = new List<Inventory>();


        public int? FinancingParameterId { get; set; }
        public FinancingParameter FinancingParameter { get; set; }

    }
}
