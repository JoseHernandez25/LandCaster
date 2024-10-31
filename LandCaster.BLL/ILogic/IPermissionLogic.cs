using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.ILogic
{
    public interface IPermissionLogic
    {
        Task<IEnumerable<Permission>> GetPermissionsAsync();
    }
}
