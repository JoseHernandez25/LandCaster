using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs.FurnituresDTOS
{
    public class GetFurnituresDTO
    {
          public int pageNumber { get; set; }
          public  int pageSize { get; set; }
          public  string? term  { get; set; }
          public  bool? withTrashed  { get; set; }


    }
}
