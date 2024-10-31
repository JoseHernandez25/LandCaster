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
    public interface IInventoryLogic
    {
        Task<PaginationResponse<Inventory>> GetInventoryAsync(PaginationDTO parameters);
        Task<Inventory> AddInventoryAsync(Inventory inventory);
        Task<Inventory> UpdateInventoryAsync(int id, Inventory inventory);
        Task<Inventory> DeleteInventoryAsync(int id);
        Task<IEnumerable<Product>> GetProductAsync();
        
        Task<Inventory> getInvetoryOfProduct(string code);
    }
}
