using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.Entities;
using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class PurchaseOrderRepository : Repository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
