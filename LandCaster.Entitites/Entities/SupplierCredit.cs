using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    public class SupplierCredit : TimeStamp
    {
        public int Id { get; set; }
        public string Description { get; set; }

        //Relations
        public ICollection<Supplier> Suppliers { get; } = new List<Supplier>();
    }
}
