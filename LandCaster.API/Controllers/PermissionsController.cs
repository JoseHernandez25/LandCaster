using LandCaster.BLL.ILogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LandCaster.API.Controllers
{
    [Route("api/permissions")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        //private readonly IManageLogic _manageLogic;
        private readonly IPermissionLogic _permissionLogic;
        public PermissionsController(IPermissionLogic permissionLogic)
        {
            _permissionLogic = permissionLogic;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult>Get()
        {
            var permisssion = await _permissionLogic.GetPermissionsAsync();
            return Ok(permisssion);
        }

        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }
    }
}
