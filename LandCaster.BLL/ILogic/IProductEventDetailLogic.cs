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
    public interface IProductEventDetailLogic
    {
        Task<PaginationResponse<ProductEventDetail>> GetProductEventDetailAsync(PaginationDTO parameters);
            Task<ProductEventDetail> AddProductEventDetailAsync(ProductEventDetail ProductEventDetail);
        Task<ProductEventDetail> UpdateProductEventDetailAsync(int id, ProductEventDetail ProductEventDetail);
        Task<ProductEventDetail> DeleteProductEventDetailAsync(int id);
    }
}
