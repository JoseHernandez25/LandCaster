using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(DrawerSlideConfiguration))]
    public class DrawerSlide : TimeStamp
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public string? Description { get; set; }
        public double? IncreaseFactor { get; set; }
        public bool? IsSimple { get; set; }

        //Relations
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public int DrawerSlideTypeId { get; set; }
        public DrawerSlideType DrawerSlideType { get; set; } = null!;
        public List<DrawerSlideDrwsComponent> DrawerSlideDrwsComponents { get; } = new();
        public int? FinancingParameterId { get; set; }

        public FinancingParameter FinancingParameter { get; set; } = null!;
        public List<DrawerSlideForQuotation> DrawerSlideForQuotations { get; } = new();






        [NotMapped]
        public double CostDrawerSlide
        {
            get
            {
                return DrawerSlideDrwsComponents
                    .Where(ddc => ddc.Component != null)
                    .Sum(ddc => (ddc.Component?.Cost ?? 0) * ddc.Quantity);

            }
        }

        [NotMapped]
        public double PriceDrawerSlide
        {
            get
            {
                if (FinancingParameter == null)
                {
                    return 0;
                }

                double factor = (IncreaseFactor is null || IncreaseFactor == 0)
                                ? FinancingParameter.Value
                                : IncreaseFactor.Value;
                return CostDrawerSlide * factor;
            }
        }


    }
}
