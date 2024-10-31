using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(FinancingParameterConfiguration))]

    public class FinancingParameter : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; } 
        public float Value { get; set; }
        public FinancingParametersType FinancingParametersType { get; set; }
        public ICollection<ExternalAccessory> ExternalAccesories { get; } = new List<ExternalAccessory>();
        public ICollection<DrawerSlide> DrawerSlides { get; } = new List<DrawerSlide>();
        public ICollection<Hinge> Hinges { get; } = new List<Hinge>();


    }

}
