using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(CourierConfiguration))]

    public class Courier : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Supplier> Suppliers { get; } = new();
    }
}
