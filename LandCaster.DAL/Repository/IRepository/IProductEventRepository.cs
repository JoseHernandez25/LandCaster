using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository.IRepository
{
    public interface IProductEventRepository : IRepository<ProductEvent>
    {
        Task<IEnumerable<ProductEvent>> GetAllAsync(Expression<Func<ProductEvent, bool>> filter = null);

    }
}
