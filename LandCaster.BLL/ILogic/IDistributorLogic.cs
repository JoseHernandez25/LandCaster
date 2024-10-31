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
    public interface IDistributorLogic
    {
        Task<PaginationResponse<Distributor>> GetDistributorAsync(PaginationDTO parameters);
        Task<Distributor> AddDistributorAsync(Distributor distributor);
        Task<Distributor> DeleteDistributorAsync(int id);
        Task<Distributor> UpdateDistributorAsync(int id, Distributor distributor);
    }
}
