using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/areas")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public AreaController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<AreaController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Area>> Get(
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


            return await _manageLogic.Area.GetAreasAsync(parameters);
        }

        // GET api/<AreaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AreaController>
        [HttpPost,Authorize]
        public async Task<IActionResult> Post(Area line)
        {
            if (line == null)
            {
                return BadRequest("El Objeto Collineor es Nulo");
            }
            var createdColor = await _manageLogic.Area.AddAreaAsync(line);

            return CreatedAtAction("Get", new { id = createdColor.Id }, createdColor);
        }

        // PUT api/<AreaController>/5
        [HttpPut("{id}"),Authorize]
        public async Task<IActionResult> Put(int id, Area area)
        {
            if (area == null)
            {
                return BadRequest("El Objeto Color es Nulo");
            }
            var createdColor = await _manageLogic.Area.UpdateAreaAsync(id, area);

            return CreatedAtAction("Get", new { id = createdColor.Id }, createdColor);

        }

        // DELETE api/<AreaController>/5
        [HttpDelete("{id}"),Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var createdColor = await _manageLogic.Area.DeleteAreaAsync(id);

            return CreatedAtAction("Get", new { id = createdColor.Id }, createdColor);
        }
    }
}
