using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(CategoryConfiguration))]
    public class Category : TimeStamp

    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ICollection<SubCategory> SubCategories { get; } = new List<SubCategory>();

    }
}
