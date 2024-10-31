using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(AccesorieTypeConfiguration))]
    public class AccessoryType : TimeStamp
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string? Description { get; set; }
            //Relation
            public ICollection<ExternalAccessory> ExternalAccessories { get; } = new List<ExternalAccessory>();
        }
    }

