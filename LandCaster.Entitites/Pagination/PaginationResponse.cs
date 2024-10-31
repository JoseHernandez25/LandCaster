using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Pagination
{
    public class PaginationResponse<TEntity>
    {
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public object? Prev { get; set; }
        public object? Next { get; set; }
        public List<TEntity>? Data { get; set; }
    }

}
