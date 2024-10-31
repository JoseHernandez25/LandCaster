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
    public class PurchaseOrderDetailLogic : IPurchaseOrderDetailLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseOrderDetailLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<PurchaseOrderDetail>> GetPurchaseOrderDetailAsync()
        {
            var PurchaseOrderDetails = await _unitOfWork.PurchaseOrderDetail.Get(
                filter: null,
                orderBy: null,
                properties: "", // Agrega la propiedad Components a las propiedades incluidas
                isTracking: true
            );
            return PurchaseOrderDetails;
        }


    }
}
