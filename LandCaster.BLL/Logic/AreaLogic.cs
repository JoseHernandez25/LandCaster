using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;

namespace LandCaster.BLL.Logic
{
    public class AreaLogic : IAreaLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public AreaLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<Area>> GetAreasAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<Area>, IOrderedQueryable<Area>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");
            bool? withTrashed = parameters.Parameters.ContainsKey("withTrashed") ?
                (bool.TryParse(parameters.Parameters["withTrashed"].ToString(), out bool parsedValue) ? parsedValue : (bool?)null)
                : (bool?)true;

            Func<IQueryable<Area>, IOrderedQueryable<Area>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                _ => null
            };

            orderBy = value;
            var areas = _unitOfWork.Area.PaginateGetAsync(
              parameters: parameters,
              filter: area => string.IsNullOrEmpty(term) || area.Name.Contains(term),
              orderBy: orderBy,
              relationships: "AreasRoutes",
              isTracking: false
          );

            var paginationResponse =await PaginationHelper.CreatePaginationResponse(areas, parameters.PageNumber);

            return paginationResponse;

        }



        public async Task<Area> AddAreaAsync(Area area)
        {
            var createColor = _unitOfWork.Area.Create(area);
            await _unitOfWork.Save();

            return area;
        }

        public async Task<Area> DeleteAreaAsync(int id)
        {
            var area = await _unitOfWork.Area.Find(id);

            area.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Area.Update(area);
            await _unitOfWork.Save();
            return area;
        }

        public async Task<Area> UpdateAreaAsync(int id, Area area)
        {
            _unitOfWork.Area.Update(area);
            await _unitOfWork.Save();
            return area;
        }
    }
}
