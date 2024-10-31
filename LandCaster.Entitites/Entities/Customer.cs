using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(CustomerConfiguration))]
    public class Customer : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }

        public DateTime? BirthDate { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public CustomerType CustomerType { get; set; }
        public Frequency Frequency { get; set; }

        public string Address { get; set; }
        public string? Rfc { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }

    }

    public enum CustomerType
    {
        [EnumMember(Value = "Doméstico")]
        domestic,

        [EnumMember(Value = "Comercial")]
        commercial,

    }

    public enum Frequency
    {
        [EnumMember(Value = "Seguido")]
        often,

        [EnumMember(Value = "No tan Seguido")]
        noOften,


    }
}
