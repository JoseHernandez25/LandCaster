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
    public interface IHingeComponentLogic
    {
        Task<PaginationResponse<HingeComponent>> GetHingeComponentAsync(PaginationDTO parameters);
        Task<HingeComponent> AddHingeComponentAsync(HingeComponent hingeComponent);
        Task<HingeComponent> UpdateHingeComponentAsync(int id, HingeComponent hingeComponent);
        Task<HingeComponent> DeleteHingeComponentAsync(int id);

        Task<List<Brand>> GetBrands();
        Task<List<HingeComponent>> GetComponentsByBrand(int brandId);

    }
}














