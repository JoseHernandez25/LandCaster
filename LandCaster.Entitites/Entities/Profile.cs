using LandCaster.Entities.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(ProfileConfiguration))]
    public class Profile : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public IFormFile? file { get; set; }
        public string? Path { get; set; }

        public ICollection<DoorModel> DoorModels { get; } = new List<DoorModel>();
    }
}
