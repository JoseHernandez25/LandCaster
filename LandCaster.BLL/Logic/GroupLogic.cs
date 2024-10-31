using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LandCaster.BLL.Logic
{
    public class GroupLogic : IGroupLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<Group>> GetGroupAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<Group>, IOrderedQueryable<Group>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");


            Func<IQueryable<Group>, IOrderedQueryable<Group>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                _ => null
            };




            orderBy = value;
            var groups = _unitOfWork.Group.PaginateGetAsync(
                parameters: parameters,
                filter: h =>
                      (string.IsNullOrEmpty(term) || h.Name.Contains(term)),
                orderBy: orderBy,
                relationships: "",
                isTracking: false
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(groups, parameters.PageNumber);

            return paginationResponse;

        }

        public async Task<Group> AddGroupAsync(Group group)
        {

            var createGroup = _unitOfWork.Group.Create(group);
            await _unitOfWork.Save();

            return group;
        }
        public async Task<Group> UpdateGroupAsync(int id, Group group)
        {
            _unitOfWork.Group.Update(group);
            await _unitOfWork.Save();
            return group;
        }

        public async Task<Group> DeleteGroupAsync(int id)
        {
            var group = await _unitOfWork.Group.Find(id);

            group.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Group.Update(group);
            await _unitOfWork.Save();
            return group;
        }

    }

}

