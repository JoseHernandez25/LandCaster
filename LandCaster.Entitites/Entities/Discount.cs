using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(DiscountConfiguration))]
    public class Discount : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public int SupplierId {  get; set; }   
        public Supplier Supplier {  get; set; }
    }
}
