using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;

namespace LandCaster.BLL.ILogic
{
    public interface IColorLogic
    {
        Task<PaginationResponse<Color>> GetColorAsync(PaginationDTO parameters);
        Task<Color> AddColorAsync(Color color);
        Task<Color> UpdateColorAsync(int id,Color color);
        Task<Color> DeleteColorAsync(int id);

        Task<List<Brand>> GetBrands();

    }
}
