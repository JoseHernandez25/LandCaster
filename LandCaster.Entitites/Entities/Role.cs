using LandCaster.Entities.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entitites.Entities
{
    [EntityTypeConfiguration(typeof(RoleConfiguration))]

    public class Role : IdentityRole<int>
    {

        public string Description { get; set; }

        public List<User> Users { get; } = new();

        public List<Permission> Permissions { get; } = new();
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
