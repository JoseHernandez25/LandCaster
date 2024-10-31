using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LandCaster.BLL.ILogic
{
    public interface IPurchaseOrderLogic
    {
        Task<IEnumerable<PurchaseOrder>> GetPurchaseOrderAsync();
    }
}
