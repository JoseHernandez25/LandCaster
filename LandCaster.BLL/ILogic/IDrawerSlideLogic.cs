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
    public interface IDrawerSlideLogic
    {
        Task<PaginationResponse<DrawerSlide>> GetDrawerSlideAsync(PaginationDTO parameters);
        Task<DrawerSlide> AddDrawerSlideAsync(AddDrawerSlideDTO addDrawerSlideDTO);
        Task<DrawerSlide> UpdateDrawerSlideAsync(int id, UpdateDrawerSlideDTO updateDrawerSlideDTO);
        Task<DrawerSlide> DeleteDrawerSlideAsync(int id);
        Task<List<Brand>> GetBrands();


        Task<DrawerSlide> UpdateDrawerSlideWithoutModifyingComponentsAsync(int id, DrawerSlide drawerSlide);

    }
}
