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
    public class AccessoryTypeLogic : IAccesorieTypeLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccessoryTypeLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<AccessoryType>> GetAccessoryTypeAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<AccessoryType>, IOrderedQueryable<AccessoryType>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");


            Func<IQueryable<AccessoryType>, IOrderedQueryable<AccessoryType>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                _ => null
            };




            orderBy = value;
            var AccessoryTypes = _unitOfWork.AccesorieType.PaginateGetAsync(
                parameters: parameters,
                filter: h =>
                      (string.IsNullOrEmpty(term) || h.Name.Contains(term)),
                orderBy: orderBy,
                relationships: "ExternalAccessories",
                isTracking: false
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(AccessoryTypes, parameters.PageNumber);

            return paginationResponse;

        }

        public async Task<AccessoryType> AddAccessoryTypeAsync(AccessoryType AccessoryType)
        {

            var createAccessoryType = _unitOfWork.AccesorieType.Create(AccessoryType);
            await _unitOfWork.Save();

            return AccessoryType;
        }
        public async Task<AccessoryType> UpdateAccessoryTypeAsync(int id, AccessoryType AccessoryType)
        {
            _unitOfWork.AccesorieType.Update(AccessoryType);
            await _unitOfWork.Save();
            return AccessoryType;
        }

        public async Task<AccessoryType> DeleteAccessoryTypeAsync(int id)
        {
            var AccessoryType = await _unitOfWork.AccesorieType.Find(id);

            AccessoryType.DeletedAt = DateTime.UtcNow;
            _unitOfWork.AccesorieType.Update(AccessoryType);
            await _unitOfWork.Save();
            return AccessoryType;
        }

    }
}
