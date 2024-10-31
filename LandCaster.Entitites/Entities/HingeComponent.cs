using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(HingeComponentConfiguration))]
    public class HingeComponent : TimeStamp
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }


        // Relaciones
        public int CurrencieId { get; set; }
        public Currencie Currencie { get; set; }
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<HingeHingeComponent> HingeHingeComponents { get; } = new();
    }
}
