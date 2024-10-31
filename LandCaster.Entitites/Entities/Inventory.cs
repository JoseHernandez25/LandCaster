using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(InventoryConfiguration))]
    public class Inventory : TimeStamp
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int MaximumStock { get; set; }
        public int MinimumStock { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int FactoryId { get; set; }
        public Factory Factory { get; set; } = null!;

    }
}
