using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.DoorsModels;
using LandCaster.Entities.DTOs.Hinges;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/doormodel")]
    [ApiController]
    public class DoorModelController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public DoorModelController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<DoorModelController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<DoorModel> >Get(
            int pageNumber,
            int pageSize,
            string? term = null,
            string? modelId = null,
            string? lineId = null,
            string? routeId = null,
            string? joineryId = null,
            string? joineryTypeId = null,
            string? materialTypeId = null,
            string? orderByAsc = null,
            string? orderBy = null,
            string? withTrashed = null
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

            if (modelId != null)
                parameters.Parameters.Add("modelId", modelId);

            if (lineId != null)
                parameters.Parameters.Add("lineId", lineId);

            if (routeId != null)
                parameters.Parameters.Add("routeId", routeId);

            if (joineryId != null)
                parameters.Parameters.Add("joineryId", joineryId);

            if (joineryTypeId != null)
                parameters.Parameters.Add("joineryTypeId", joineryTypeId);

            if(materialTypeId != null)
                parameters.Parameters.Add("materialTypeId", materialTypeId);
            if (orderByAsc != null)
                parameters.Parameters.Add("orderByAsc", orderByAsc);

            if (orderBy != null)
                parameters.Parameters.Add("orderBy", orderBy);

            return await _manageLogic.DoorModel.GetDoorModelAsync(parameters);
        }

        // GET api/<DoorModelController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("getModel"), Authorize]
        public async Task<IEnumerable<Model>> GetModel()
        {
            return await _manageLogic.DoorModel.GetModelAsync();
        }

        [HttpGet("getMaterialType"), Authorize]
        public async Task<IEnumerable<MaterialType>> GetMaterialType()
        {
            return await _manageLogic.DoorModel.GetMaterialType();
        }

        [HttpGet("getJoinery"), Authorize]
        public async Task<IEnumerable<Joinery>> GetJoinery()
        {
            return await _manageLogic.DoorModel.GetJoinery();
        }
        [HttpGet("getJoineryType"), Authorize]
        public async Task<IEnumerable<JoineryType>> GetJoineryType()
        {
            return await _manageLogic.DoorModel.GetJoineryType();
        }
        [HttpGet("getRoute"), Authorize]
        public async Task<IEnumerable<Entities.Entities.Route>> GetRoute()
        {
            return await _manageLogic.DoorModel.GetRoute();
        }

        [HttpGet("getLine"), Authorize]
        public async Task<IEnumerable<Line>> GetLine()
        {
            return await _manageLogic.DoorModel.GetLine();
        }

        [HttpGet("getTypesBoxJourney"), Authorize]
        public async Task<IEnumerable<TypesBoxJourney>> GetTypesBoxJourney()
        {
            return await _manageLogic.DoorModel.GetTypesBoxJourney();
        }

        [HttpGet("getdoorType"), Authorize]
        public async Task<IEnumerable<DoorType>> GetDoorType()
        {
            return await _manageLogic.DoorModel.GetDoorType();
        }
        [HttpGet("getcenterType"), Authorize]
        public async Task<IEnumerable<CenterType>> GetCenterType()
        {
            return await _manageLogic.DoorModel.GetCenterType();
        }
        [HttpGet("getmolding"), Authorize]
        public async Task<IEnumerable<Molding>> GetCMolding()
        {
            return await _manageLogic.DoorModel.GetMolding();
        }


        // POST api/<DoorModelController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] AddDoorModelDTO addDoorModelDTO)
        {
            if (addDoorModelDTO.DoorModel == null)
            {
                return BadRequest("El Objeto minel es Nulo");
            }

            // Puedes realizar lógica adicional aquí, como validaciones, antes de agregar el color.
            // Por ejemplo, podrías verificar si el color ya existe, etc.

            var createdDoorModel = await _manageLogic.DoorModel.AddDoorModelAsync(addDoorModelDTO);

            return CreatedAtAction("Get", new { id = createdDoorModel.Id }, createdDoorModel);
        }

        // PUT api/<DoorModelController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, UpdateDoorModelDTO updateDoorModelDTO)
        {
            if (updateDoorModelDTO.DoorModel == null)
            {
                return BadRequest("El objeto es nulo");
            }
            var createdDoorModel = await _manageLogic.DoorModel.UpdateDoorModelAsync(id, updateDoorModelDTO);

            return CreatedAtAction("Get", new { id = createdDoorModel.Id }, createdDoorModel);
        }

        // DELETE api/<DoorModelController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdDoorModel = await _manageLogic.DoorModel.DeleteDoorModelAsync(id);

            return CreatedAtAction("Get", new { id = createdDoorModel.Id }, createdDoorModel);

        }
    }
}
