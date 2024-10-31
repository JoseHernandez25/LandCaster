using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Route = LandCaster.Entities.Entities.Route;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/routes")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public RouteController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<RouteController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Route> >Get(
            int pageNumber,
            int pageSize,
            string? term = null,
            string? orderByAsc = null,
            string? orderBy = null
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


            return await _manageLogic.Route.GetRoutesAsync(parameters);
        }

        // GET api/<RouteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RouteController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(Route route)
        {
            if (route == null)
            {
                return BadRequest("El Objeto Collineor es Nulo");
            }
            var createdColor = await _manageLogic.Route.AddRouteAsync(route);

            return CreatedAtAction("Get", new { id = createdColor.Id }, createdColor);
        }

        // PUT api/<RouteController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, Route route)
        {
            if (route == null)
            {
                return BadRequest("El Objeto Color es Nulo");
            }
            var createdColor = await _manageLogic.Route.UpdateRouteAsync(id, route);

            return CreatedAtAction("Get", new { id = createdColor.Id }, createdColor);

        }

        // DELETE api/<RouteController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var createdColor = await _manageLogic.Route.DeleteRouteAsync(id);

            return CreatedAtAction("Get", new { id = createdColor.Id }, createdColor);
        }
    }
}
