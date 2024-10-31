using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/models")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public ModelController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<ModelController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Model> >Get(int pageNumber, int pageSize, string? term)
        {
            if (term is null) term = "";

            var parameters = new PaginationDTO();

            parameters.PageNumber = pageNumber;
            parameters.PageSize = pageSize;
            parameters.OrderBy = "DEC";
            parameters.Parameters = new Dictionary<string, object> { { "term", term } };

            return await _manageLogic.Model.GetModelAsync(parameters);
        }

        // GET api/<ModelController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ModelController>
        [HttpPost]
        public async Task<IActionResult> Post(Model model)
        {
            if (model == null)
            {
                return BadRequest("El Objeto Modelo es Nulo");
            }


            var createdModel = await _manageLogic.Model.AddModelAsync(model);

            return CreatedAtAction("Get", new { id = createdModel.Id }, createdModel);
        }

        // PUT api/<ModelController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, Model model)
        {
            if (model == null)
            {
                return BadRequest("El Objeto Model es Nulo");
            }
            var createdModel = await _manageLogic.Model.UpdateModelAsync(id, model);

            return CreatedAtAction("Get", new { id = createdModel.Id }, createdModel);

        }

        // DELETE api/<ModelController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdModel = await _manageLogic.Model.DeleteModelAsync(id);

            return CreatedAtAction("Get", new { id = createdModel.Id }, createdModel);

        }
    }
}
