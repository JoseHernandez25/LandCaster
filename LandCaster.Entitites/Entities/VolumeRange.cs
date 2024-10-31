using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(VolumeRangeConfiguration))]

    public class VolumeRange : TimeStamp
    {
        public int Id { get; set; }
        public int StartRange { get; set; }
        public int? EndRange { get; set; }
        [EnumDataType(typeof(Discounts))]
        public Discounts DiscountType { get; set; }
        public List<DiscountType> DiscountTypes { get; } = new List<DiscountType>();

        // Método para validar el valor de DiscountType
        public bool IsValidDiscountType()
        {
            return Enum.IsDefined(typeof(Discounts), DiscountType);
        }
    }

    public enum Discounts
    {
        [Description("Kitchen")]
        Kitchen = 1,

        [Description("Door")]
        Door = 2
    }


}

