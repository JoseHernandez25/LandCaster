using LandCaster.Entities.Configurations;
using LandCaster.Entitites.Entities;
using Microsoft.EntityFrameworkCore;


namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(DistributorConfiguration))]

    public class Distributor : TimeStamp
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Rfc { get; set; }

        public User User { get; set; }

        public ICollection<Store> Stores { get; } = new List<Store>();
        public string Address { get; set; }

    }
}
