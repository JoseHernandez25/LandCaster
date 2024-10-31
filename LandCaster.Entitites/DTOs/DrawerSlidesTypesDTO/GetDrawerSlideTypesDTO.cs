using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs.DrawerSlidesTypesDTO
{
    public class GetDrawerSlideTypesDTO
    {
         public int pageNumber { get; set; }
        public  int pageSize { get; set; }
        public  string? term { get; set; }
        public  string? brandId { get; set; }
        public  string? orderByAsc { get; set; }
        public  string? orderBy { get; set; }
        public  string? withTrashed { get; set; }
        public  bool? isSimple { get; set; }
    }
}
