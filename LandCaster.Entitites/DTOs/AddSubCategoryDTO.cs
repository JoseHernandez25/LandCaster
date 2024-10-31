using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs
{
    public class AddSubCategoryDTO
    {
        public  SubCategory SubCategory { get; set; }
        public int[] BrandIds { get; set; }
    }
}
