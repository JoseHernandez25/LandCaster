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
    public interface IFactoryLogic
    {
        Task<PaginationResponse<Factory>> GetFactoryAsync(PaginationDTO parameters);
        Task<Factory> AddFactoryAsync(Factory factory);
        Task<Factory> UpdateFactoryAsync(int id, Factory factory);
        Task<Factory> DeleteFactoryAsync(int id);
    }
}
