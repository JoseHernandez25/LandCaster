using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(SubSubCategoryConfiguration))]
    public class SubSubCategory : TimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SubCategory SubCategory { get; set; } = null!;
        public int SubCategoryId { get; set; }

    }
}
