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
    public interface IModelLogic
    {
        Task<PaginationResponse<Model>> GetModelAsync(PaginationDTO parameters);
        Task<Model> AddModelAsync(Model model);

        Task<Model> UpdateModelAsync(int id, Model model);
        Task<Model> DeleteModelAsync(int id);
    }
}
