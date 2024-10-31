using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs
{
    public class PaginationDTO
    {
        [Required]
        public int PageSize { get; set; }
        [Required]
        public int PageNumber { get; set; }
        public string OrderBy { get; set; }
        public Dictionary<string, object>? Parameters { get; set; }

    }
}
