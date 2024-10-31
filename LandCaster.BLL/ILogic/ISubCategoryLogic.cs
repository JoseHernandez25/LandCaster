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
    public interface ISubCategoryLogic
    {
        Task<PaginationResponse<SubCategory>> GetSubCategoryAsync(PaginationDTO parameters);
        Task<SubCategory> AddSubCategoryAsync(AddSubCategoryDTO addSubCategoryDTO);
        Task<SubCategory> UpdateSubCategoryAsync(int id, SubCategory subcategory);
        Task<SubCategory> DeleteSubCategoryAsync(int id);
    }
}
