using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using LandCaster.Entities.Configurations;
using LandCaster.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LandCaster.Entitites.Entities
{
    [EntityTypeConfiguration(typeof(UserConfiguration))]

    public class User : IdentityUser<int>
    {
        //relationships one to one
        public string? ProfilePhoto { get; set; }
        public int RoleId { get; set; }

        public Employee Employee { get; set; }

        public Role Role { get; set; }
        public Distributor Distributor { get; set; }

        public List<Permission> Permissions { get; } = new();
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
     
}
