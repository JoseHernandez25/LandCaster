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
    public interface IDrawerSlideComponentLogic
    {
        Task<PaginationResponse<DrawerSlideComponent>> GetDrawerSlideComponentAsync(PaginationDTO parameters);
        Task<DrawerSlideComponent> AddDrawerSlideComponentAsync(DrawerSlideComponent drawerSlideComponent);
        Task<DrawerSlideComponent> UpdateDrawerSlideComponentAsync(int id, DrawerSlideComponent drawerSlideComponent);
        Task<DrawerSlideComponent> DeleteDrawerSlideComponentAsync(int id);
        Task<List<Brand>> GetBrands();

        Task<List<DrawerSlideDrwsComponent>> UpdatDrawerSlideDrwsComponentAsync(int id, DrawerSlideDrwsComponent drawerSlideDrwsComponent);
        Task<List<DrawerSlideComponent>> GetDrawerSlideComponents();


    }
}
