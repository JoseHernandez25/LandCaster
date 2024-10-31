using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class DrawerSlideTypeLogic : IDrawerSlideTypeLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public DrawerSlideTypeLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<DrawerSlideType>> GetDrawerSlideTypeAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            var isSimple = parameters.Parameters.ContainsKey("isSimple") ? Convert.ToBoolean(parameters.Parameters["isSimple"]) : (bool?)null;

            Func<IQueryable<DrawerSlideType>, IOrderedQueryable<DrawerSlideType>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");
            bool? withTrashed = parameters.Parameters.ContainsKey("withTrashed") ?
                (bool.TryParse(parameters.Parameters["withTrashed"].ToString(), out bool parsedValue) ? parsedValue : (bool?)null)
                : (bool?)true;

            Func<IQueryable<DrawerSlideType>, IOrderedQueryable<DrawerSlideType>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                _ => null
            };


            Expression<Func<DrawerSlideType, bool>> filterCondition = c =>
            ((withTrashed == true && c.DeletedAt != null) ||
            (withTrashed == false && c.DeletedAt == null) || withTrashed == null) &&
             ((string.IsNullOrEmpty(term) || c.Name.Contains(term))) &&
             (!isSimple.HasValue || c.IsSimple == isSimple);



            orderBy = value;
            var externalAccesories = _unitOfWork.DrawerSlideType.PaginateGetAsync(
              parameters: parameters,
              filter: filterCondition,
              orderBy: orderBy,
              relationships: "DrawerSlides",
              isTracking: false,
              withTrashed: withTrashed == null ? true : Convert.ToBoolean(withTrashed)
          );

            var paginationResponse =await PaginationHelper.CreatePaginationResponse(externalAccesories, parameters.PageNumber);

            return paginationResponse;

        }



        public async Task<DrawerSlideType> AddDrawerSlideTypeAsync(AddDrawerSlideTypeDTO addDrawerSlideTypeDTO)
        {
            var drawerSlideType = new DrawerSlideType();
            drawerSlideType.Name = addDrawerSlideTypeDTO.Name; // Corrección del nombre de la propiedad
            drawerSlideType.IsSimple = addDrawerSlideTypeDTO.isSimple;
            await _unitOfWork.DrawerSlideType.Create(drawerSlideType);
            await _unitOfWork.Save();

            foreach (var drawerSlideDto in addDrawerSlideTypeDTO.drawerSlides)
            {
                var drawerSlide = new DrawerSlide(); 
                drawerSlide.DrawerSlideTypeId = drawerSlideType.Id; 
                drawerSlide.IsSimple = drawerSlideType.IsSimple;
                drawerSlide.Name = drawerSlideDto.Name;
                drawerSlide.Code = drawerSlideDto.Code;
                drawerSlide.Cost = 0;
                drawerSlide.Price = 0;
                //drawerSlide.IsSimple = drawerSlideType.IsSimple;
                drawerSlide.FinancingParameterId = 1;

                await _unitOfWork.DrawerSlide.Create(drawerSlide);
            }

            await _unitOfWork.Save();

            return drawerSlideType;
        }


        public async Task<DrawerSlideType> UpdateDrawerSlideTypeAsync(int id, DrawerSlideType DrawerSlideType)
        {
            _unitOfWork.DrawerSlideType.Update(DrawerSlideType);
            await _unitOfWork.Save();
            return DrawerSlideType;
        }

        public async Task<DrawerSlideType> DeleteDrawerSlideTypeAsync(int id)
        {
            var DrawerSlideType = await _unitOfWork.DrawerSlideType.Find(id);

            DrawerSlideType.DeletedAt = DateTime.UtcNow;
            _unitOfWork.DrawerSlideType.Update(DrawerSlideType);
            await _unitOfWork.Save();
            return DrawerSlideType;
        }

        public Task<List<DrawerSlideType>> GetAllDrawerSlideTypesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
