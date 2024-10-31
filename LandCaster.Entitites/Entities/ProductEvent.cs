using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(ProductEventConfiguration))]
    public class ProductEvent : TimeStamp
    {
        public int Id { get; set; }
        public string Folio { get; set; }
        public string Type { get; set; }
        public string? Status { get; set; }
        public ICollection<ProductEventDetail> ProductEventDetails { get; } = new List<ProductEventDetail>();
        public Employee Employee { get; set; } = null!;
        public int EmployeeId { get; set; }

    }

}
