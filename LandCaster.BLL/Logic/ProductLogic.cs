using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Migrations;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.ProductDTO;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entities.Specfications;
using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class ProductLogic : IProductLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<PaginationResponse<Product>> GetProductAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");
            var brandId = parameters.Parameters.ContainsKey("brandId") ? Convert.ToInt32(parameters.Parameters["brandId"]) : (int?)null;
            var SubSubCategoryId = parameters.Parameters.ContainsKey("subsubcategoryId") ? Convert.ToInt32(parameters.Parameters["subsubcategoryId"]) : (int?)null;
            bool? withTrashed = parameters.Parameters.ContainsKey("withTrashed") ? (bool.TryParse(parameters.Parameters["withTrashed"].ToString(), out bool parsedValue) ? parsedValue : (bool?)null)
            : (bool?)true;

            Func<IQueryable<Product>, IOrderedQueryable<Product>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                "code" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Code) : query.OrderByDescending(c => c.Code),
                "description" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Description) : query.OrderByDescending(c => c.Description),
                "cost" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Cost) : query.OrderByDescending(c => c.Cost),
                "price" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Price) : query.OrderByDescending(c => c.Price),
                "increasefactor" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.IncreaseFactor) : query.OrderByDescending(c => c.IncreaseFactor),
                "brand" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Brand.Name) : query.OrderByDescending(c => c.Brand.Name),
                "subsubcategories" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.SubSubCategory.Name) : query.OrderByDescending(c => c.SubSubCategory.Name),
                "units" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Unit.Name) : query.OrderByDescending(c => c.Unit.Name),
                "currencies" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Currencie.Name) : query.OrderByDescending(c => c.Currencie.Name),
                _ => null
            };
            Expression<Func<Product, bool>> filterCondition = c =>
                ((withTrashed == true && c.DeletedAt != null) ||
                (withTrashed == false && c.DeletedAt == null) ||
                withTrashed == null) &&
                ((string.IsNullOrEmpty(term) || c.Name.Contains(term)) ||
                c.Code.Contains(term) ||
                c.Brand.Name.Contains(term)) &&
                (!brandId.HasValue || c.BrandId == brandId) &&
                (!SubSubCategoryId.HasValue || c.SubSubCategoryId == SubSubCategoryId);



            orderBy = value;
            var products = _unitOfWork.Product.PaginateGetAsync(
                parameters: parameters,
                filter: filterCondition,
                orderBy: orderBy,
                relationships: "SubSubCategory,Brand,Unit,Currencie,FinancingParameter",
                isTracking: false,
                withTrashed: withTrashed == null ? true : Convert.ToBoolean(withTrashed)

            );

            var paginationResponse =await PaginationHelper.CreatePaginationResponse(products, parameters.PageNumber);

            return paginationResponse;
        }
        public async Task<Product> AddProductAsync(Product product)
        {

            //if (existProduct != null)
            //{
            //    // Retorna una tupla indicando que el producto ya existe y no se pudo agregar
            //    return new AddProductResponse { exists = true, Product = existProduct };
            //    //Console.WriteLine("Este producto ya existe");
            //}

            var createdProduct = _unitOfWork.Product.Create(product);
            await _unitOfWork.Save();

            // Retorna una tupla indicando que el producto se creó exitosamente
            return product;
        }



        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            _unitOfWork.Product.Update(product);
            await _unitOfWork.Save();
            return product;
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            var product = await _unitOfWork.Product.Find(id);

            product.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Product.Update(product);
            await _unitOfWork.Save();
            return product;
        }

        public async Task<List<Brand>> GetBrands()
        {
            var brands = await _unitOfWork.Brand.Get();

            return brands;
        }

        public async Task<Product> GetProductByCodeAsync(string code)
        {
            return await _unitOfWork.Product.Fisrt(p => p.Code.Contains(code));
        }


        public async Task<Product> VerifyProduct(string code)
        {
            var product = await _unitOfWork.Product.Fisrt(p => p.Code.Contains(code), properties: "Inventories");
            return product;
        }

    }
}
