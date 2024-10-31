using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs.ProductDTO
{
    public class AddProductResponse
    {
        public Product? Product { get; set; }
        public bool exists { get; set; }
    }
}
