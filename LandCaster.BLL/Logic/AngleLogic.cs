using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class AngleLogic : IAngleLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public AngleLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<Angle>> GetAngleAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<Angle>, IOrderedQueryable<Angle>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");
           

            Func<IQueryable<Angle>, IOrderedQueryable<Angle>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                _ => null
            };




            orderBy = value;
            var angles = _unitOfWork.Angle.PaginateGetAsync(
                parameters: parameters,
                filter: h =>
                      (string.IsNullOrEmpty(term) || h.Name.Contains(term)),
                orderBy: orderBy,
                relationships: "Hinges",
                isTracking: false
            );

            var paginationResponse =await PaginationHelper.CreatePaginationResponse(angles, parameters.PageNumber);

            return paginationResponse;

        }

        public async Task<Angle> AddAngleAsync(Angle Angle)
        {

            var createAngle = _unitOfWork.Angle.Create(Angle);
            await _unitOfWork.Save();

            return Angle;
        }
        public async Task<Angle> UpdateAngleAsync(int id, Angle Angle)
        {
            _unitOfWork.Angle.Update(Angle);
            await _unitOfWork.Save();
            return Angle;
        }

        public async Task<Angle> DeleteAngleAsync(int id)
        {
            var Angle = await _unitOfWork.Angle.Find(id);

            Angle.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Angle.Update(Angle);
            await _unitOfWork.Save();
            return Angle;
        }

    }
}
