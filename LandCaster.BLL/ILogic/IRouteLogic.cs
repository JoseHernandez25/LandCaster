using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;


namespace LandCaster.BLL.ILogic
{
    public interface IRouteLogic
    {
        Task<PaginationResponse<Route>> GetRoutesAsync(PaginationDTO parameters);
        Task<Route> AddRouteAsync(Route route);
        Task<Route> UpdateRouteAsync(int id, Route route);
        Task<Route> DeleteRouteAsync(int id);
    }
}
