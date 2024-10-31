using LandCaster.BLL;
using LandCaster.BLL.ILogic;
using LandCaster.DAL;
using LandCaster.DAL.Repository;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entitites.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LandCaster.API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        //private readonly IManageLogic _manageLogic;
        private readonly IRoleLogic _roleLogic;
        public RoleController(IRoleLogic roleLogic)
        {
            _roleLogic = roleLogic;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult>Get()
        {
            var roles = await _roleLogic.GetAllRolesAsync();
            return Ok(roles);
        }
      
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }
    }
}
