using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(PaymentTypeConfiguration))]
    public class PaymentType : TimeStamp
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public int FurnitureDiscount { get; set; }
        public int CoveredDiscount { get; set; }
        public int EquipmentDiscount { get; set; }
        public decimal? CashAdvance { get; set; }
        public decimal? Clearance { get; set; }
        public bool? Active { get; set; }
        public string? Description { get; set; }
        public int EspFurnitureDiscount { get; set; }
        public int EspCoveredDiscount { get; set; }
        public int EspEquipmentDiscount { get; set; }
        public bool? ActiveDistribuitor { get; set; }
        public bool? ActiveSeason { get; set; }
        public bool? ActiveVolume { get; set; }

    }
}
