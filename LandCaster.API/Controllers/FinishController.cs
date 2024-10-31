using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/finish")]
    [ApiController]
    public class FinishController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public FinishController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<FinishController>
        [HttpGet]
        public async Task<PaginationResponse<Finish>> Get(int pageNumber, int pageSize, string? term)
        {
            if (term is null) term = "";

            var parameters = new PaginationDTO();

            parameters.PageNumber = pageNumber;
            parameters.PageSize = pageSize;
            parameters.OrderBy = "DEC";
            parameters.Parameters = new Dictionary<string, object> { { "term", term } };

            return await _manageLogic.Finish.GetFinishAsync(parameters);
        }

        // GET api/<FinishController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FinishController>
        [HttpPost]
        public async Task<IActionResult> Post(Finish finish)
        {
            if (finish == null)
            {
                return BadRequest("El Objeto Clase Acabado es Nulo");
            }
            var createdFinish = await _manageLogic.Finish.AddFinishAsync(finish);

            return CreatedAtAction("Get", new { id = createdFinish.Id }, createdFinish);
        }


        // PUT api/<FinishController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Finish finish)
        {
            if (finish == null)
            {
                return BadRequest("El Objeto Clase Acabado es Nulo");
            }
            var createdFinish = await _manageLogic.Finish.UpdateFinishAsync(id, finish);

            return CreatedAtAction("Get", new { id = createdFinish.Id }, createdFinish);

        }

        // DELETE api/<FinishController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var createdFinish = await _manageLogic.Finish.DeleteFinishAsync(id);

            return CreatedAtAction("Get", new { id = createdFinish.Id }, createdFinish);

        }
    }
}
