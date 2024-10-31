using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(PurchaseOrderDetailConfiguration))]
    public class PurchaseOrderDetail : TimeStamp
    {
        public int Id { get; set; }
        public string Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; } = null!;

    }
}
