using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entities.Specfications;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace LandCaster.BLL.Logic
{
    public class ColorLogic : IColorLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ColorLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<PaginationResponse<Color>> GetColorAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            var brandId = parameters.Parameters.ContainsKey("brandId") ? Convert.ToInt32(parameters.Parameters["brandId"]) : (int?)null;
            var materialTypeId = parameters.Parameters.ContainsKey("materialTypeId") ? Convert.ToInt32(parameters.Parameters["materialTypeId"]) : (int?)null;
            Func<IQueryable<Color>, IOrderedQueryable<Color>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");
            bool? withTrashed = parameters.Parameters.ContainsKey("withTrashed") ?
                (bool.TryParse(parameters.Parameters["withTrashed"].ToString(), out bool parsedValue) ? parsedValue : (bool?)null)
                : (bool?)true;

            Func<IQueryable<Color>, IOrderedQueryable<Color>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "code" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Code) : query.OrderByDescending(c => c.Code),
                "supplierCode" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.SupplierCode) : query.OrderByDescending(c => c.SupplierCode),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                "brand" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Brand.Name) : query.OrderByDescending(c => c.Brand.Name),
                "materialType" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.MaterialType.Name) : query.OrderByDescending(c => c.MaterialType.Name),
                _ => null
            };
           
            
            Expression<Func<Color, bool>> filterCondition = c =>
                ((withTrashed == true && c.DeletedAt != null) ||
                 (withTrashed == false && c.DeletedAt == null) ||
                 withTrashed == null) &&
                ((string.IsNullOrEmpty(term) || c.Name.Contains(term)) ||
                 (string.IsNullOrEmpty(term) || c.Brand.Name.Contains(term)) ||
                 (string.IsNullOrEmpty(term) || c.MaterialType.Name.Contains(term))) &&
                (!brandId.HasValue || c.BrandId == brandId) &&
                (!materialTypeId.HasValue || c.MaterialTypeId == materialTypeId);



            orderBy = value;
            var colors = _unitOfWork.Color.PaginateGetAsync(
              parameters: parameters,
              filter: filterCondition,
              orderBy: orderBy,
              relationships: "SubTypeMaterials,Brand,MaterialType",
              isTracking: false,
              withTrashed: withTrashed == null ? true : Convert.ToBoolean(withTrashed)
          );

            var paginationResponse =await PaginationHelper.CreatePaginationResponse(colors, parameters.PageNumber);

            return paginationResponse;

        }


  
        public async Task<Color> AddColorAsync(Color color)
        {

            var createColor = _unitOfWork.Color.Create(color);
            await _unitOfWork.Save();

            return color;
        }
        public async Task<Color> UpdateColorAsync(int id, Color color)
        {
            _unitOfWork.Color.Update(color);
            await _unitOfWork.Save();
            return color;
        }

        public async Task<Color> DeleteColorAsync(int id)
        {   var color = await _unitOfWork.Color.Find(id);
             
            color.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Color.Update(color);
            await _unitOfWork.Save();
            return color;
        }

        public async Task<List<Brand>> GetBrands()
        {
            //var brands = _unitOfWork.Color.GetBrands();
            var subCategory = await _unitOfWork.SubCategory.Get(
                c => (c.Id == 1),
                orderBy: null,
                properties: "Brands",
                isTracking: false);

            // Seleccionar y aplanar las marcas de todas las subcategorías
            var brands = subCategory.SelectMany(sc => sc.Brands).ToList();

            return brands;
        }
        
    }
}


