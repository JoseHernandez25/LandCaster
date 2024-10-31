using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entities.Specfications;

namespace LandCaster.BLL.Logic
{
    public class HingeComponentLogic : IHingeComponentLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public HingeComponentLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<HingeComponent>> GetHingeComponentAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            var brandId = parameters.Parameters.ContainsKey("brandId") ? Convert.ToInt32(parameters.Parameters["brandId"]) : (int?)null;
            var currencieId = parameters.Parameters.ContainsKey("currencieId") ? Convert.ToInt32(parameters.Parameters["currencieId"]) : (int?)null;
            Func<IQueryable<HingeComponent>, IOrderedQueryable<HingeComponent>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");

            Func<IQueryable<HingeComponent>, IOrderedQueryable<HingeComponent>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "code" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Code) : query.OrderByDescending(c => c.Code),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                "brand" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Brand.Name) : query.OrderByDescending(c => c.Brand.Name),
                "Price" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Brand.Name) : query.OrderByDescending(c => c.Price),
                "Currencie" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Brand.Name) : query.OrderByDescending(c => c.Currencie.Name),

                _ => null
            };

            orderBy = value;
            var hingeComponents = _unitOfWork.HingeComponent.PaginateGetAsync(
                parameters: parameters,
                filter: h =>
                    (string.IsNullOrEmpty(term) || h.Name.Contains(term) || h.Code.Contains(term)) &&
                    (!brandId.HasValue || (h.BrandId != null && h.BrandId == brandId)) &&
                    (!currencieId.HasValue || (h.CurrencieId != null && h.CurrencieId == currencieId)),
                orderBy: orderBy,
                relationships: "Currencie,Brand,HingeHingeComponents.Hinge",
                isTracking: false
            );

            var paginationResponse =await PaginationHelper.CreatePaginationResponse(hingeComponents, parameters.PageNumber);

            return paginationResponse;
        } 

        public async Task<HingeComponent> AddHingeComponentAsync(HingeComponent hingeComponent)
        {
            var createHingeComponent = _unitOfWork.HingeComponent.Create(hingeComponent);
            await _unitOfWork.Save();

            return hingeComponent;
        }

        public async Task<HingeComponent> UpdateHingeComponentAsync(int id, HingeComponent hingeComponent)
        {
            _unitOfWork.HingeComponent.Update(hingeComponent);
            await _unitOfWork.Save();
            return hingeComponent;
        }

        public async Task<HingeComponent> DeleteHingeComponentAsync(int id)
        {
            var hingeComponent = await _unitOfWork.HingeComponent.Find(id);

            hingeComponent.DeletedAt = DateTime.UtcNow;
            _unitOfWork.HingeComponent.Update(hingeComponent);
            await _unitOfWork.Save();
            return hingeComponent;
        }

        public async Task<List<Brand>> GetBrands()
        {
            //var subCategory = await _unitOfWork.SubCategory.Get(
            //    c => (c.Id == 1),
            //    orderBy: null,
            //    properties: "Brands",
            //    isTracking: false);

            //var brands = subCategory.SelectMany(sc => sc.Brands).ToList();
            var brands = await _unitOfWork.Brand.Get();

            return brands;
        }

        public async Task<List<HingeComponent>> GetComponentsByBrand(int brandId)
        {
            var components = await _unitOfWork.HingeComponent.Get(
                c => (c.BrandId == brandId),
                orderBy: null,
                properties: "Currencie,Brand,HingeHingeComponents.Hinge",
                isTracking: false);

            return components.ToList();
        }


    }
}