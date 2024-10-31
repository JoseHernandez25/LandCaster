using LandCaster.Entities.Configurations;
using LandCaster.Entitites.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(FactoryConfiguration))]
    public class Factory : TimeStamp
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public int CityId { get; set; }
        public City City { get; set; } = null!;
        public List<Supplier> Suppliers { get; } = new();
        public ICollection<Employee> Employees { get; } = new List<Employee>();
    }
}
