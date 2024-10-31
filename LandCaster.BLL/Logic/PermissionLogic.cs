using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class PermissionLogic : IPermissionLogic
    {
        private readonly IPermissionRepository _permissionRepository;
        public PermissionLogic(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        public async Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return await _permissionRepository.GetAllPermissionAsync();
        }
    }
}
