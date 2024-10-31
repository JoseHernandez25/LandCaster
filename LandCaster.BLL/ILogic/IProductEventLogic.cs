using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.ILogic
{
    public interface IProductEventLogic
    {
        Task<PaginationResponse<ProductEvent>> GetProductEventAsync(PaginationDTO parameters);
        Task<ProductEvent> AddProductEventAsync(ProductEvent productevent);
        Task<ProductEvent> UpdateProductEventAsync(int id, ProductEvent productevent);
        Task<ProductEvent> DeleteProductEventAsync(int id);
    }
}
