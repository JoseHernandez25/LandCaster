
using LandCaster.BLL;
using LandCaster.DAL.Migrations;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entities.Specfications;
using LandCaster.Entitites.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LandCaster.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public UserController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;
        }

        [HttpGet, Authorize]
        public async Task<PaginationResponse<User> >Get(
            int pageNumber, 
            int pageSize, 
            string? term,
            string? orderByAsc = null,
            string? orderBy = null,
            string? roleId = null
            ) 
        {
            var parameters = new PaginationDTO
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Parameters = new Dictionary<string, object>()
            };

            if (term != null)
                parameters.Parameters.Add("term", term);

            if (orderByAsc != null)
                parameters.Parameters.Add("orderByAsc", orderByAsc);

            if (orderBy != null)
                parameters.Parameters.Add("orderBy", orderBy);

            if (roleId != null)
                parameters.Parameters.Add("roleId", roleId);

            return await _manageLogic.User.GetUserAsync(parameters);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Post(User user)
        {
            if (user == null)
            {
                return BadRequest("El Objeto usuario es Nulo");
            }

            // Puedes realizar lógica adicional aquí, como validaciones, antes de agregar el color.
            // Por ejemplo, podrías verificar si el color ya existe, etc.

            var createdUser = await _manageLogic.User.AddUserAsync(user);

            return CreatedAtAction("Get", new { id = createdUser.Id }, createdUser);
        }
        [HttpGet("{id}"),  Authorize]
        public string Get(string id)
        {
            return "value";
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(string id, User user)
        {
            if(user == null)
            {
                return BadRequest("El objeto usuario es nulo");               
            }
            var createdUser = await _manageLogic.User.UpdateUserAsync(id, user);
            return CreatedAtAction("Get", new {Id  = createdUser.Id}, createdUser);
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            var createdUser = await _manageLogic.User.DeleteUserAsync(id);
            return CreatedAtAction("Get", new {Id = createdUser.Id}, createdUser);
        }
    }
}
