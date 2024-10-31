using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System.Linq.Expressions;

namespace LandCaster.BLL.Logic
{
    public class ExternalAccessoryLogic : IExternalAccessoryLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExternalAccessoryLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<ExternalAccessory>> GetExternalAccessoryAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            var AccesorieTypeId = parameters.Parameters.ContainsKey("AccesorieTypeId") ? Convert.ToInt32(parameters.Parameters["AccesorieTypeId"]) : (int?)null;
            var supplierId = parameters.Parameters.ContainsKey("supplierId") ? Convert.ToInt32(parameters.Parameters["supplierId"]) : (int?)null;

            Func<IQueryable<ExternalAccessory>, IOrderedQueryable<ExternalAccessory>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : true;
            bool? withTrashed = parameters.Parameters.ContainsKey("withTrashed") ?
                (bool.TryParse(parameters.Parameters["withTrashed"].ToString(), out bool parsedValue) ? parsedValue : (bool?)null)
                : (bool?)true;

            Func<IQueryable<ExternalAccessory>, IOrderedQueryable<ExternalAccessory>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "code" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Code) : query.OrderByDescending(c => c.Code),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                "brand" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Brand.Name) : query.OrderByDescending(c => c.Brand.Name),
                "AccesorieTypeId" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.AccesorieType.Name) : query.OrderByDescending(c => c.AccesorieType.Name),
                "supplierId" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Supplier.Name) : query.OrderByDescending(c => c.Supplier.Name),

                _ => null
            };


            Expression<Func<ExternalAccessory, bool>> filterCondition = c =>
            ((withTrashed == true && c.DeletedAt != null) ||
            (withTrashed == false && c.DeletedAt == null) ||
             withTrashed == null) &&
            ((string.IsNullOrEmpty(term) || c.Name.Contains(term)) ||
             c.Code.Contains(term) ||
             c.Brand.Name.Contains(term) || c.Supplier.Name.Contains(term) ||
             c.AccesorieType.Name.Contains(term)) &&
            (!AccesorieTypeId.HasValue || c.AccesorieTypeId == AccesorieTypeId) &&
             (!supplierId.HasValue || c.SupplierId == supplierId);





            orderBy = value;
            var externalAccesories = _unitOfWork.ExternalAccessory.PaginateGetAsync(
              parameters: parameters,
              filter: filterCondition,
              orderBy: orderBy,
              relationships: "Supplier,FinancingParameter,AccesorieType,Brand,Currencie",
              isTracking: false,
              withTrashed: withTrashed == null ? true : Convert.ToBoolean(withTrashed)
          );

            var paginationResponse =await PaginationHelper.CreatePaginationResponse(externalAccesories, parameters.PageNumber);

            return paginationResponse;

        }

        public async Task<ExternalAccessory> AddExternalAccessoryAsync(ExternalAccessory ExternalAccessory)
        {

            var createExternalAccessory = _unitOfWork.ExternalAccessory.Create(ExternalAccessory);
            await _unitOfWork.Save();

            return ExternalAccessory;
        }
        public async Task<ExternalAccessory> UpdateExternalAccessoryAsync(int id, ExternalAccessory ExternalAccessory)
        {
            _unitOfWork.ExternalAccessory.Update(ExternalAccessory);
            await _unitOfWork.Save();
            return ExternalAccessory;
        }

        public async Task<ExternalAccessory> DeleteExternalAccessoryAsync(int id)
        {
            var ExternalAccessory = await _unitOfWork.ExternalAccessory.Find(id);

            ExternalAccessory.DeletedAt = DateTime.UtcNow;
            _unitOfWork.ExternalAccessory.Update(ExternalAccessory);
            await _unitOfWork.Save();
            return ExternalAccessory;
        }

        public async Task<List<Brand>> GetBrands()
        {

            var brands = await _unitOfWork.Brand.Get();

            return brands;
        }

        public async Task<List<AccessoryType>> GetAccesorieType()
        {

            var accesorietypes = await _unitOfWork.AccesorieType.Get();

            return accesorietypes;
        }

        public async Task<List<Supplier>> GetSuppliers()
        {

            var suppliers = await _unitOfWork.Supplier.Get();

            return suppliers;
        }

    }
}
