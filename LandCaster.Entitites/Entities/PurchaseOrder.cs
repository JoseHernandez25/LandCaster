using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(PurchaseOrderConfiguration))]
    public class PurchaseOrder : TimeStamp
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Boolean Approved { get; set; }
        public Supplier Supplier { get; set; } = null!;
        public int SuplierId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; } = new List<PurchaseOrderDetail>();

    }
}
