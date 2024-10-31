using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.Hinges;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/hinges")]
    [ApiController]
    public class HingeController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public HingeController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Hinge> >Get(
     int pageNumber,
     int PageSize,
     string? term = null,
     string? brandId = null,
     string? HingeTypeId = null,
     string? orderByAsc = null,
     string? orderBy = null)
        {
            var parameters = new PaginationDTO
            {
                PageNumber = pageNumber,
                PageSize = PageSize,
                Parameters = new Dictionary<string, object>()
            };

            if (term != null)
                parameters.Parameters.Add("term", term);

            if (brandId != null)
                parameters.Parameters.Add("brandId", brandId);

            if (HingeTypeId != null)
                parameters.Parameters.Add("HingeTypeId", HingeTypeId);

            if (orderByAsc != null)
                parameters.Parameters.Add("orderByAsc", orderByAsc);

            if (orderBy != null)
                parameters.Parameters.Add("orderBy", orderBy);

            return await _manageLogic.Hinge.GetHingeAsync(parameters);
        }


        // GET api/<HingeComponentsController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<HingeComponentsController>
        //[HttpPost, Authorize]
        //public async Task<IActionResult> Post(Hinge hinge)
        //{
        //    if (hinge == null)
        //    {
        //        return BadRequest("El objeto componente bisagra es nulo");
        //    }
        //    var createdHinge = await _manageLogic.Hinge.AddHingeAsync(hinge);

        //    return CreatedAtAction("Get", new { id = createdHinge.Id }, createdHinge);
        //}

        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] AddHingeDTO addHingeDTO)
        {
            if (addHingeDTO.Hinge == null)
            {
                return BadRequest("El Objeto Hinge es Nulo");
            }

            // Puedes realizar lógica adicional aquí, como validaciones, antes de agregar el color.
            // Por ejemplo, podrías verificar si el color ya existe, etc.

            var createdHinge = await _manageLogic.Hinge.AddHingeAsync(addHingeDTO);

            return CreatedAtAction("Get", new { id = createdHinge.Id }, createdHinge);
        }

        // PUT api/<HingeComponentsController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, UpdateHingeDTO updateHingeDTO)
        {
            if (updateHingeDTO == null)
            {
                return BadRequest("El objeto componente bisagra es nulo");
            }
            var updatedHinge = await _manageLogic.Hinge.UpdateHingeAsync(id, updateHingeDTO);

            return CreatedAtAction("Get", new { id = updatedHinge.Id }, updatedHinge);
        }

        // DELETE api/<HingeComponentsController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedHinge = await _manageLogic.Hinge.DeleteHingeAsync(id);

            return CreatedAtAction("Get", new { id = deletedHinge.Id }, deletedHinge);
        }

        // Obtener marcas
        [HttpGet("get-brands-hinge"), Authorize]
        public async Task<List<Brand>> GetBrands()
        {
            return await _manageLogic.Hinge.GetBrands();
        }

        [HttpGet("get-hinge-type"), Authorize]
        public async Task<List<HingeType>> GetHingeTypes()
        {
            return await _manageLogic.Hinge.GetHingeTypes();
        }
        // DELETE api/hinges/{hingeId}/components/{componentId}
        [HttpDelete("{hingeId}/components/{componentId}"), Authorize]
        public async Task<IActionResult> DeleteHingeComponent(int hingeId, int componentId)
        {
            try
            {
                // Llama al método en la lógica de gestión para eliminar el componente de la bisagra.
                await _manageLogic.Hinge.DeleteHingeComponentAsync(hingeId, componentId);

                // Devuelve una respuesta de éxito si el componente se eliminó correctamente.
                return Ok("Componente de bisagra eliminado correctamente");
            }
            catch (Exception ex)
            {
                // Si ocurre un error durante la eliminación del componente, devuelve un código de estado 500 con un mensaje de error.
                return StatusCode(500, "Error al eliminar el componente de la bisagra");
            }
        }


    }

}


