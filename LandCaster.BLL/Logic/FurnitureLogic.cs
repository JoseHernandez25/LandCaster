using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System.Linq.Expressions;

namespace LandCaster.BLL.Logic
{
    public class FurnitureLogic : IFurnitureLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public FurnitureLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<Furniture>> GetFurnituresAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<Furniture>, IOrderedQueryable<Furniture>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");
            bool? withTrashed = parameters.Parameters.ContainsKey("withTrashed") ?
                (bool.TryParse(parameters.Parameters["withTrashed"].ToString(), out bool parsedValue) ? parsedValue : (bool?)null)
                : (bool?)true;

            Func<IQueryable<Furniture>, IOrderedQueryable<Furniture>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "code" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Code) : query.OrderByDescending(c => c.Code),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                _ => null
            };


            Expression<Func<Furniture, bool>> filterCondition = c =>
            ((withTrashed == true && c.DeletedAt != null) ||
            (withTrashed == false && c.DeletedAt == null) ||
             withTrashed == null) &&
            ((string.IsNullOrEmpty(term) || c.Name.Contains(term) || c.Code.Contains(term)));

            orderBy = value;
            var externalAccesories =  _unitOfWork.Furniture.PaginateGetAsync(
              parameters: parameters,
              filter: filterCondition,
              orderBy: orderBy,
              relationships: "LandCasterProducts,,HingesForQuotations.Hinge,FurnitureExternalAccessories.ExternalAccessory,FurnitureDrawers.Drawer.DrawerSlideForQuotations.DrawerSlide,FurnitureAccessories.InternalAccessory,FurnitureStructures.Structure",
              isTracking: false,
              withTrashed: withTrashed == null ? true : Convert.ToBoolean(withTrashed)
          );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(externalAccesories, parameters.PageNumber);

            return  paginationResponse;


        }

        public Task<Furniture> AddtFurnitureAsync(Furniture furniture)
        {
            throw new NotImplementedException();
        }


        public Task<Furniture> DelettFurnitureAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Furniture> UpdatetFurnitureAsync(int id, Furniture furniture)
        {
            throw new NotImplementedException();
        }
    }
}
