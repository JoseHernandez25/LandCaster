using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Migrations;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.Hinges;
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
    public class DrawerSlideLogic : IDrawerSlideLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public DrawerSlideLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<PaginationResponse<DrawerSlide>> GetDrawerSlideAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            var brandId = parameters.Parameters.ContainsKey("brandId") ? Convert.ToInt32(parameters.Parameters["brandId"]) : (int?)null;
            var DrawerSlideTypeId = parameters.Parameters.ContainsKey("DrawerSlideTypeId") ? Convert.ToInt32(parameters.Parameters["DrawerSlideTypeId"]) : (int?)null;
            //var isSimple = parameters.Parameters.ContainsKey("isSimple") ? Convert.ToBoolean(parameters.Parameters["isSimple"]) : (bool?)null;

            Func<IQueryable<DrawerSlide>, IOrderedQueryable<DrawerSlide>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");

            Func<IQueryable<DrawerSlide>, IOrderedQueryable<DrawerSlide>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "code" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Code) : query.OrderByDescending(c => c.Code),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                "brand" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Brand.Name) : query.OrderByDescending(c => c.Brand.Name),
                "DrawerSlideType" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.DrawerSlideType.Name) : query.OrderByDescending(c => c.DrawerSlideType.Name),
                _ => null
            };

            orderBy = value;
            var DrawerSlides = _unitOfWork.DrawerSlide.PaginateGetAsync(
                parameters: parameters,
                filter: h =>
                    (string.IsNullOrEmpty(term) || h.Name.Contains(term) || h.Code.Contains(term)) &&
                    (!brandId.HasValue || (h.BrandId != null && h.BrandId == brandId)) &&
                    (!DrawerSlideTypeId.HasValue || (h.DrawerSlideTypeId != null && h.DrawerSlideTypeId == DrawerSlideTypeId)),
                     orderBy: orderBy,
                relationships: "Brand,DrawerSlideType,DrawerSlideDrwsComponents.Component,FinancingParameter,DrawerSlideDrwsComponents.Component.Currencie",
                isTracking: false
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(DrawerSlides, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<DrawerSlide> AddDrawerSlideAsync(AddDrawerSlideDTO addDrawerSlideDTO)
        {
            await _unitOfWork.DrawerSlide.Create(addDrawerSlideDTO.DrawerSlide);
            await _unitOfWork.Save();

            foreach (var component in addDrawerSlideDTO.Components)
            {
                var drawerSlideDrwsComponent = new DrawerSlideDrwsComponent();
                drawerSlideDrwsComponent.Quantity = component.Quantity;
                drawerSlideDrwsComponent.ComponentId = component.ComponentId;
                drawerSlideDrwsComponent.DrawerSlideId = addDrawerSlideDTO.DrawerSlide.Id;

                await _unitOfWork.DawerSlideDrwsComponent.Create(drawerSlideDrwsComponent);

            }
            await _unitOfWork.Save();
            return addDrawerSlideDTO.DrawerSlide;
        }

        //public async Task<DrawerSlide> UpdateDrawerSlideAsync(int id, UpdateDrawerSlideDTO updateDrawerSlideDTO)
        //{
        //    _unitOfWork.DrawerSlide.Update(updateDrawerSlideDTO.DrawerSlide);

        //    var drawerSlide = await _unitOfWork.DrawerSlide.Fisrt(
        //                 filter: h => h.Id == id,   
        //                 properties: "DrawerSlideDrwsComponents");

        //    foreach (var component in drawerSlide.DrawerSlideDrwsComponents)
        //    {
        //        _unitOfWork.DawerSlideDrwsComponent.Delete(component);
        //    }

        //    foreach (var component in updateDrawerSlideDTO.Components)
        //    {
        //        var drawerSlideDrwsComponent = new DrawerSlideDrwsComponent();
        //        drawerSlideDrwsComponent.Quantity = component.Quantity;
        //        drawerSlideDrwsComponent.ComponentId = component.ComponentId;
        //        drawerSlideDrwsComponent.DrawerSlideId = drawerSlide.Id;

        //        await _unitOfWork.DawerSlideDrwsComponent.Create(drawerSlideDrwsComponent);

        //    }
        //    await _unitOfWork.Save();
        //    return updateDrawerSlideDTO.DrawerSlide;
        //}

        public async Task<DrawerSlide> UpdateDrawerSlideAsync(int id, UpdateDrawerSlideDTO updateDrawerSlideDTO)
        {
            _unitOfWork.DrawerSlide.Update(updateDrawerSlideDTO.DrawerSlide);

            var drawerSlide = await _unitOfWork.DrawerSlide.Fisrt(
                         filter: h => h.Id == id,
                         properties: "DrawerSlideDrwsComponents");

            // Elimina solo los componentes que no están en la lista de actualización
            foreach (var existingComponent in drawerSlide.DrawerSlideDrwsComponents)
            {
                if (!updateDrawerSlideDTO.Components.Any(c => c.ComponentId == existingComponent.ComponentId))
                {
                    _unitOfWork.DawerSlideDrwsComponent.Delete(existingComponent);
                }
            }

            // Agrega o actualiza los componentes en la lista de actualización
            foreach (var component in updateDrawerSlideDTO.Components)
            {
                var existingComponent = drawerSlide.DrawerSlideDrwsComponents
                    .FirstOrDefault(c => c.ComponentId == component.ComponentId);

                if (existingComponent != null)
                {
                    // Actualiza el componente existente
                    existingComponent.Quantity = component.Quantity;
                    _unitOfWork.DawerSlideDrwsComponent.Update(existingComponent);
                }
                else
                {
                    // Crea un nuevo componente
                    var drawerSlideDrwsComponent = new DrawerSlideDrwsComponent
                    {
                        Quantity = component.Quantity,
                        ComponentId = component.ComponentId,
                        DrawerSlideId = drawerSlide.Id
                    };
                    await _unitOfWork.DawerSlideDrwsComponent.Create(drawerSlideDrwsComponent);
                }
            }

            await _unitOfWork.Save();
            return updateDrawerSlideDTO.DrawerSlide;
        }

        //nuevo metodo para actualizar
        public async Task<DrawerSlide> UpdateDrawerSlideWithoutModifyingComponentsAsync(int id, DrawerSlide drawerSlide)
        {
            _unitOfWork.DrawerSlide.Update(drawerSlide);
            await _unitOfWork.Save();
            return drawerSlide;
        }
        public async Task<DrawerSlide> DeleteDrawerSlideAsync(int id)
        {
            var DrawerSlide = await _unitOfWork.DrawerSlide.Find(id);

            DrawerSlide.DeletedAt = DateTime.UtcNow;
            _unitOfWork.DrawerSlide.Update(DrawerSlide);
            await _unitOfWork.Save();
            return DrawerSlide;
        }

        public async Task<List<Brand>> GetBrands()
        {

            var brands = await _unitOfWork.Brand.Get();

            return brands;
        }

    }
}

