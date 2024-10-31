using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(ProductEventDetailConfiguration))]
    public class ProductEventDetail : TimeStamp
    {
        public int Id { get; set; }
        public string Quantity { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public Inventory Inventory { get; set; } = null!;
        public int InventoryId { get; set; }
        public ProductEvent ProductEvent { get; set; } = null!;
        public int ProductEventId {  get; set; }

    }
}
