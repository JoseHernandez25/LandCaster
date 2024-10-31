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
    public interface IExternalAccessoryLogic
    {
        Task<PaginationResponse<ExternalAccessory>> GetExternalAccessoryAsync(PaginationDTO parameters);
        Task<ExternalAccessory> AddExternalAccessoryAsync(ExternalAccessory ExternalAccessory);
        Task<ExternalAccessory> UpdateExternalAccessoryAsync(int id, ExternalAccessory ExternalAccessory);
        Task<ExternalAccessory> DeleteExternalAccessoryAsync(int id);
        Task<List<Brand>> GetBrands();
        Task<List<AccessoryType>> GetAccesorieType();
        Task<List<Supplier>> GetSuppliers();


    }
}