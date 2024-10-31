using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;

namespace LandCaster.BLL.Logic
{
    public class RouteLogic : IRouteLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public RouteLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<Route>> GetRoutesAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<Route>, IOrderedQueryable<Route>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");
            bool? withTrashed = parameters.Parameters.ContainsKey("withTrashed") ?
                (bool.TryParse(parameters.Parameters["withTrashed"].ToString(), out bool parsedValue) ? parsedValue : (bool?)null)
                : (bool?)true;

            Func<IQueryable<Route>, IOrderedQueryable<Route>>? value = orderByField switch
            {
                "code" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Code) : query.OrderByDescending(c => c.Code),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),

                _ => null
            };

            orderBy = value;
            var routes = _unitOfWork.Route.PaginateGetAsync(
              parameters: parameters,
              filter: route => string.IsNullOrEmpty(term) || route.Code.Contains(term),
              orderBy: orderBy,
              relationships: "AreasRoutes.Area",
              isTracking: false
          );

           var paginationResponse =await PaginationHelper.CreatePaginationResponse(routes, parameters.PageNumber);

           return paginationResponse;

        }



        public async Task<Route> AddRouteAsync(Route route)
        {
            var createColor = _unitOfWork.Route.Create(route);
            await _unitOfWork.Save();

            return route;
        }

        public async Task<Route> DeleteRouteAsync(int id)
        {
            var Route = await _unitOfWork.Route.Find(id);

            Route.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Route.Update(Route);
            await _unitOfWork.Save();
            return Route;
        }

        public async Task<Route> UpdateRouteAsync(int id, Route route)
        {
            _unitOfWork.Route.Update(route);
            await _unitOfWork.Save();
            return route;
        }
    }
}
