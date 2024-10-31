using LandCaster.Entities.Configurations;
using LandCaster.Entitites.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(SupplierConfiguration))]
    public class Supplier : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Website { get; set; }
        public string Representative { get; set; }
        public string Observations { get; set; }
        public string Account { get; set; }
        public String Creditor { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string RFC { get; set; }



        public int? SupplierCreditId { get; set; }
        public SupplierCredit SupplierCredit { get; set; } = null!;
        public List<Factory> Factories { get; } = new();
        public List<Courier> Couriers { get; } = new();
        public ICollection<Discount> Discounts { get; } = new List<Discount>();
        public ICollection<ExternalAccessory> ExternalAccesories { get; } = new List<ExternalAccessory>();



    }
    //public enum TypeCredit
    //{
    //    [EnumMember(Value = "No establecido")]
    //    NoEstablecido,

    //    [EnumMember(Value = "8 Días")]
    //    Días8,

    //    [EnumMember(Value = "15 Días")]
    //    Días15,

    //    [EnumMember(Value = "20 Días")]
    //    Días20,

    //    [EnumMember(Value = "30 Días")]
    //    Dias30,

    //    [EnumMember(Value = "45 Días")]
    //    Días45,

    //    [EnumMember(Value = "60 Días")]
    //    Días60
    //}
}
