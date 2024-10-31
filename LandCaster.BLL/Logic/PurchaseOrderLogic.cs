using System;
using System.Collections.Generic;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class PurchaseOrderLogic : IPurchaseOrderLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseOrderLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<PurchaseOrder>> GetPurchaseOrderAsync()
        {
            var PurchaseOrders = await _unitOfWork.PurchaseOrder.Get(
                filter: null,
                orderBy: null,
                properties: "", // Agrega la propiedad Components a las propiedades incluidas
                isTracking: true
            );
            return PurchaseOrders;
        }


    }
}
