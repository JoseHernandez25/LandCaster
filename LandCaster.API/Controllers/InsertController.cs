using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/insert")]
    [ApiController]
    public class InsertController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public InsertController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<InsertController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Insert>> Get(int pageNumber, int pageSize, string? term)
        {
            if (term is null) term = "";

            var parameters = new PaginationDTO();

            parameters.PageNumber = pageNumber;
            parameters.PageSize = pageSize;
            parameters.OrderBy = "DEC";
            parameters.Parameters = new Dictionary<string, object> { { "term", term } };

            return await _manageLogic.Insert.GetInsertAsync(parameters);
        }

        // GET api/<InsertController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InsertController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(Insert insert)
        {
            if (insert == null)
            {
                return BadRequest("El Objeto Insert es Nulo");
            }


            var createdInsert = await _manageLogic.Insert.AddInsertAsync(insert);

            return CreatedAtAction("Get", new { id = createdInsert.Id }, createdInsert);
        }

        // PUT api/<InsertController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, Insert insert)
        {
            if (insert == null)
            {
                return BadRequest("El Objeto Insert es Nulo");
            }
            var createdInsert = await _manageLogic.Insert.UpdateInsertAsync(id, insert);

            return CreatedAtAction("Get", new { id = createdInsert.Id }, createdInsert);

        }

        // DELETE api/<InsertController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdInsert = await _manageLogic.Insert.DeleteInsertAsync(id);

            return CreatedAtAction("Get", new { id = createdInsert.Id }, createdInsert);

        }
    }
}
