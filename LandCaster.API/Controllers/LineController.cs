using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/lines")]
    [ApiController]
    public class LineController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public LineController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<LineController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Line> >Get(
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


            return await _manageLogic.Line.GetLinesAsync(parameters);
        }

        // GET api/<LineController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LineController>
        [HttpPost]
        public async Task<IActionResult> Post(Line line)
        {
            if (line == null)
            {
                return BadRequest("El Objeto Collineor es Nulo");
            }
            var createdColor = await _manageLogic.Line.AddLineAsync(line);

            return CreatedAtAction("Get", new { id = createdColor.Id }, createdColor);
        }

        // PUT api/<LineController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Line line)
        {
            if (line == null) 
            {
                return BadRequest("El Objeto Color es Nulo");
            }
            var createdColor = await _manageLogic.Line.UpdateLineAsync(id, line);

            return CreatedAtAction("Get", new { id = createdColor.Id }, createdColor);

        }

        // DELETE api/<LineController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var createdColor = await _manageLogic.Line.DeleteLineAsync(id);

            return CreatedAtAction("Get", new { id = createdColor.Id }, createdColor);
        }
    }
}
