using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.ILogic
{
    public interface IGroupLogic
    {
        Task<PaginationResponse<Group>> GetGroupAsync(PaginationDTO parameters);
        Task<Group> AddGroupAsync(Group Group);
        Task<Group> UpdateGroupAsync(int id, Group Group);
        Task<Group> DeleteGroupAsync(int id);

    }
}
