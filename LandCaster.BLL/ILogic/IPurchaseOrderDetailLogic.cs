using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.ILogic
{
    public interface IPurchaseOrderDetailLogic
    {
        Task<IEnumerable<PurchaseOrderDetail>> GetPurchaseOrderDetailAsync();
    }
}
