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
    public interface ICategoryLogic
    {
        Task<PaginationResponse<Category>> GetCategoryAsync(PaginationDTO parameters);
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(int id, Category category);
        Task<Category> DeleteCategoryAsync(int id);
    }
}
