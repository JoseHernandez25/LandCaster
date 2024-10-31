using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(EmployeeConfiguration))]
    public class Employee : TimeStamp
    {
        public int Id { get; set; }
        public int? Code { get; set; }
        public string? Name { get; set; }
       
        public int? StoreId { get; set; }
        public int? FactoryId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public Status? Status { get; set; }

        public string? Address { get; set; }
        public string? CURP { get; set; }
        public string? NSS { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public string? RFC { get; set; }    
        public Store Store { get; set; } = null!;
        public Factory Factory { get; set; } = null!;
        //relationships one to one 
        public User User { get; set; }
         public int? UserId { get; set; }
        public ICollection<Event> Events { get; } = new List<Event>();

        public ICollection<ProductEvent> ProductEvents { get; } = new List<ProductEvent>();

    }

    public enum Status
    {
        [EnumMember(Value = "Baja")]
        dismiss,

        [EnumMember(Value = "Alta")]
        enrolled,
    }
}
