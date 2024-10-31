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
    [EntityTypeConfiguration(typeof(SubCategoryConfiguration))]
    public class SubCategory : TimeStamp
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public Category Category { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }
 
        public ICollection<Brand> Brands { get; } = new List<Brand>();

        public ICollection<SubSubCategory> SubSubCategories { get; } = new List<SubSubCategory>();


    }
}
