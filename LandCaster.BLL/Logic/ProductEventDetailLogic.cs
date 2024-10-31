using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class ProductEventDetailLogic : IProductEventDetailLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductEventDetailLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<ProductEventDetail>> GetProductEventDetailAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<ProductEventDetail>, IOrderedQueryable<ProductEventDetail>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");

            Func<IQueryable<ProductEventDetail>, IOrderedQueryable<ProductEventDetail>>? value = orderByField switch
            {
                "quantity" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Quantity) : query.OrderByDescending(c => c.Quantity),
                "price" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Price) : query.OrderByDescending(c => c.Price),
                _ => null
            };

            orderBy = value;
            var ProductEventDetail = _unitOfWork.ProductEventDetail.PaginateGetAsync(
                parameters: parameters,
                filter: c =>
                    (string.IsNullOrEmpty(term)),
                orderBy: orderBy,
                relationships: "ProductEvent,Inventory",
                isTracking: false
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(ProductEventDetail, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<ProductEventDetail> AddProductEventDetailAsync(ProductEventDetail ProductEventDetail)
        {
            var createProductEventDetail = _unitOfWork.ProductEventDetail.Create(ProductEventDetail);
            await _unitOfWork.Save();

            return ProductEventDetail;
        }

        public async Task<ProductEventDetail> UpdateProductEventDetailAsync(int id, ProductEventDetail ProductEventDetail)
        {
            _unitOfWork.ProductEventDetail.Update(ProductEventDetail);
            await _unitOfWork.Save();
            return ProductEventDetail;
        }

        public async Task<ProductEventDetail> DeleteProductEventDetailAsync(int id)
        {
            var ProductEventDetail = await _unitOfWork.ProductEventDetail.Find(id);

            ProductEventDetail.DeletedAt = DateTime.UtcNow;
            _unitOfWork.ProductEventDetail.Update(ProductEventDetail);
            await _unitOfWork.Save();
            return ProductEventDetail;
        }

    }
}
