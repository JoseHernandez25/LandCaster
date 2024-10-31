using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/doorType")]
    [ApiController]
    public class DoorTypeController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;
        private readonly IWebHostEnvironment _enviroment;

        public DoorTypeController(IManageLogic manageLogic, IWebHostEnvironment enviroment)
        {
            _manageLogic = manageLogic;
            _enviroment = enviroment;
        }
        // GET: api/<DoorTypeController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<DoorType>> Get(int pageNumber, int pageSize, string? term)
        {
            if (term is null) term = "";

            var parameters = new PaginationDTO();

            parameters.PageNumber = pageNumber;
            parameters.PageSize = pageSize; 
            parameters.OrderBy = "DEC";
            parameters.Parameters = new Dictionary<string, object> { { "term", term } };

            return await _manageLogic.DoorType.GetDoorTypeAsync(parameters);
        }

        // GET api/<DoorTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DoorTypeController>
        //[HttpPost, Authorize]
        //public async Task<IActionResult> Post(DoorType doorType)
        //{
        //    if (doorType == null)
        //    {
        //        return BadRequest("El Objeto Tipo de Puerta es Nulo");
        //    }


        //    var createdDoorType = await _manageLogic.DoorType.AddDoorTypeAsync(doorType);

        //    return CreatedAtAction("Get", new { id = createdDoorType.Id }, createdDoorType);
        //}

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromForm] string name)
        {
            if (file == null || string.IsNullOrEmpty(file.FileName))
            {
                return BadRequest("El archivo es requerido y debe tener un nombre válido.");
            }

            if (string.IsNullOrEmpty(_enviroment.WebRootPath))
            {
                return StatusCode(500, "El entorno del servidor no está configurado correctamente.");
            }

            var uploadsFolderPath = Path.Combine(_enviroment.WebRootPath, "storage", "DoorTypes");

            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var filePath = Path.Combine(uploadsFolderPath, file.FileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var doorType = new DoorType
                {
                    Name = name,
                    Image = $"/storage/DoorTypes/{file.FileName}" // Guardar la ruta del archivo en la base de datos
                };

                await _manageLogic.DoorType.AddDoorTypeAsync(doorType);

                return Ok(new { message = "Archivo subido exitosamente", fileName = file.FileName });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error al guardar el archivo: {ex.Message}");
            }
        }


        //PUT api/<DoorTypeController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, DoorType doorType)
        {
            if (doorType == null)
            {
                return BadRequest("El Objeto Tipo de Puerta es Nulo");
            }
            var createdDoorType = await _manageLogic.DoorType.UpdateDoorTypeAsync(id, doorType);

            return CreatedAtAction("Get", new { id = createdDoorType.Id }, createdDoorType);

        }



        // DELETE api/<DoorTypeController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdDoorType = await _manageLogic.DoorType.DeleteDoorTypeAsync(id);

            return CreatedAtAction("Get", new { id = createdDoorType.Id }, createdDoorType);

        }
    }
}
