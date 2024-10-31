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
    public interface ISubSubCategoryLogic
    {
        Task<PaginationResponse<SubSubCategory>> GetSubSubCategoryAsync(PaginationDTO parameters);
        Task<SubSubCategory> AddSubSubCategoryAsync(SubSubCategory subsubcategory);
        Task<SubSubCategory> UpdateSubSubCategoryAsync(int id, SubSubCategory subsubcategory);
        Task<SubSubCategory> DeleteSubSubCategoryAsync(int id);
    }
}
