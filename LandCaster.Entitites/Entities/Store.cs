
using LandCaster.Entities.Configurations;
using LandCaster.Entitites.Entities;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(StoreConfiguration))]
    public class Store : TimeStamp
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name {  get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string? UserId { get; set; }
        public Point? Ubication { get; set; }


        //relationships one to one
        public Distributor Distributor { get; set; } = null!;

        public ICollection<Employee> Employees { get; } = new List<Employee>();
        public ICollection<Customer> Clientes { get; } = new List<Customer>();
    }
}
