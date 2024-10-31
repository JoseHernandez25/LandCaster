using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(HingeTypeConfiguration))]
    public class HingeType : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Relation

        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Hinge> Hinges { get; } = new List<Hinge>();

    }
}
