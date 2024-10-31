using LandCaster.Entities.Pagination;
using LandCaster.Entities.Specfications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.helpers
{
    public class PaginationHelper
    {
        public static async Task<PaginationResponse<T>> CreatePaginationResponse<T>(Task<PagedList<T>> items, int currentPage)
        {
            var asyncItems = await items;
            var totalPages = asyncItems.MetaData.TotalPages;
            var prevDisabled = currentPage <= 1 ? new { status = "disabled", pageNumber = 1 } : new { status = "enabled", pageNumber = currentPage - 1 };
            var nextDisabled = currentPage >= totalPages ? new { status = "disabled", pageNumber = totalPages } : new { status = "enabled", pageNumber = currentPage + 1 };

            return new PaginationResponse<T>
            {
                TotalPages = totalPages,
                TotalCount = asyncItems.MetaData.TotalCount,
                PageSize = asyncItems.MetaData.PageSize,
                PageNumber = currentPage,
                Prev = prevDisabled,
                Next = nextDisabled,
                Data = asyncItems
            };
        }
    }
}
