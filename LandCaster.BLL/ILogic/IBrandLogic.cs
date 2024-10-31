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
    public interface IBrandLogic
    {
        Task<PaginationResponse<Brand>> GetBrandAsync(PaginationDTO parameters);
        Task<Brand> AddBrandAsync(Brand brand);
        Task<Brand> UpdateBrandAsync(int id, Brand brand);
        Task<Brand> DeleteBrandAsync(int id);
    }
}
