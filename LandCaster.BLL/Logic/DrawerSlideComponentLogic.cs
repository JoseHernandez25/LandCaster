using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entities.Specfications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class DrawerSlideComponentLogic : IDrawerSlideComponentLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public DrawerSlideComponentLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<DrawerSlideComponent>> GetDrawerSlideComponentAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            var brandId = parameters.Parameters.ContainsKey("brandId") ? Convert.ToInt32(parameters.Parameters["brandId"]) : (int?)null;
            Func<IQueryable<DrawerSlideComponent>, IOrderedQueryable<DrawerSlideComponent>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");

            Func<IQueryable<DrawerSlideComponent>, IOrderedQueryable<DrawerSlideComponent>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "supplierCode" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.SupplierCode) : query.OrderByDescending(c => c.SupplierCode),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                "brand" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Brand.Name) : query.OrderByDescending(c => c.Brand.Name),
                _ => null
            };

            orderBy = value;
            var DrawerSlideComponent = _unitOfWork.DrawerSlideComponent.PaginateGetAsync(
                parameters: parameters,
                filter: c =>
                    (string.IsNullOrEmpty(term) || c.Name.Contains(term) || c.SupplierCode.Contains(term)) &&
                    (!brandId.HasValue || (c.BrandId != null && c.BrandId == brandId)),
                orderBy: orderBy,
                relationships: "Brand,Unit,Currencie,DrawerSlideDrwsComponents.DrawerSlide",
                isTracking: false
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(DrawerSlideComponent, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<DrawerSlideComponent> AddDrawerSlideComponentAsync(DrawerSlideComponent DrawerSlideComponent)
        {
            var createDrawerSlideComponent = _unitOfWork.DrawerSlideComponent.Create(DrawerSlideComponent);
            await _unitOfWork.Save();

            return DrawerSlideComponent;
        }

        public async Task<DrawerSlideComponent> UpdateDrawerSlideComponentAsync(int id, DrawerSlideComponent DrawerSlideComponent)
        {
            _unitOfWork.DrawerSlideComponent.Update(DrawerSlideComponent);
            await _unitOfWork.Save();
            return DrawerSlideComponent;
        }

        public async Task<DrawerSlideComponent> DeleteDrawerSlideComponentAsync(int id)
        {
            var DrawerSlideComponent = await _unitOfWork.DrawerSlideComponent.Find(id);

            DrawerSlideComponent.DeletedAt = DateTime.UtcNow;
            _unitOfWork.DrawerSlideComponent.Update(DrawerSlideComponent);
            await _unitOfWork.Save();
            return DrawerSlideComponent;
        }

        public async Task<List<Brand>> GetBrands()
        {
            var brands = await _unitOfWork.Brand.Get();

            return brands;
        }

       public async Task<List<DrawerSlideComponent>> GetDrawerSlideComponents()
        {
            var drawerSlideComponents = await _unitOfWork.DrawerSlideComponent.Get(
                properties: "Brand,Currencie"
                );

            return drawerSlideComponents;

        }


        public async Task<List<DrawerSlideDrwsComponent>> UpdatDrawerSlideDrwsComponentAsync(int id, DrawerSlideDrwsComponent drawerSlideDrwsComponent)
        {
            _unitOfWork.DawerSlideDrwsComponent.Update(drawerSlideDrwsComponent);
            await _unitOfWork.Save();
            var drawerSlide = await  _unitOfWork.DrawerSlide.Fisrt(
                filter: drs => drs.Id == drawerSlideDrwsComponent.DrawerSlideId,
                properties: "DrawerSlideDrwsComponents.Component.Currencie,");
            var components =  drawerSlide.DrawerSlideDrwsComponents;
            return components;
        }


    }
}