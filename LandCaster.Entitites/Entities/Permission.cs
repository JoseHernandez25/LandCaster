using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using LandCaster.Entities.Entities;

namespace LandCaster.Entitites.Entities
{
    [EntityTypeConfiguration(typeof(PermissionConfiguration))]

    public class Permission : TimeStamp
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }
        public string Description { get; set; }

        public List<Role> Roles { get; } = new();

        public List<User> Users { get; } = new();


    }
}
