using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.Discounts;
using LandCaster.Entities.DTOs.DoorsModels;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/volume-range")]
    [ApiController]
    public class VolumeRangeController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public VolumeRangeController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }

        // GET: api/<VolumeRangeController>
        [HttpGet, Authorize]
        public async Task<IEnumerable<VolumeRange>> Get()
        {
            return await _manageLogic.VolumeRange.GetVolumeRangeAsync();
        }

        // GET: api/<VolumeRangeController>
        [HttpGet("discount-type")]
        public async Task<IEnumerable<DiscountType>> GetDiscountTypes()
        {
            return await _manageLogic.VolumeRange.GetDiscountTypeAsync();
        }

        // GET api/<VolumeRangeController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<DoorModelController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] AddVolumeRangeDTO AddVolumeRangeDTO)
        {
            //if (AddVolumeRangeDTO.VolumeRange == null)
            //{
            //    return BadRequest("El Objeto minel es Nulo");
            //}


            //var createdVolumeRange = await _manageLogic.VolumeRange.AddVolumeRangeAsync(AddVolumeRangeDTO);

            //return CreatedAtAction("Get", new { id = createdVolumeRange.Id }, createdVolumeRange);
            if (AddVolumeRangeDTO.VolumeRange == null)
            {
                return BadRequest("El objeto VolumeRange es nulo");
            }

            try
            {
                var createdVolumeRange = await _manageLogic.VolumeRange.AddVolumeRangeAsync(AddVolumeRangeDTO);
                return CreatedAtAction("Get", new { id = createdVolumeRange.Id }, createdVolumeRange);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ocurrió un error inesperado", Details = ex.Message });
            }
        }




        // PUT api/<DoorModelController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, UpdateVolumenRangeDTO updateVolumenRangeDTO)
        {
            if (updateVolumenRangeDTO.VolumeRange == null)
            {
                return BadRequest("El objeto es nulo");
            }
            var createdVolumeRange = await _manageLogic.VolumeRange.UpdateVolumeRangeAsync(id, updateVolumenRangeDTO);

            return CreatedAtAction("Get", new { id = createdVolumeRange.Id }, createdVolumeRange);
        }

        //// PUT api/<DoorModelController>/5
        //[HttpPut("{id}"), Authorize]
        //public async Task<IActionResult> Put(int id, VolumeRange volumeRange)
        //{
        //    if (volumeRange == null)
        //    {
        //        return BadRequest("El objeto es nulo");
        //    }
        //    var createdVolumeRange = await _manageLogic.VolumeRange.UpdateVolumeRangeAsync(id, volumeRange);

        //    return CreatedAtAction("Get", new { id = createdVolumeRange.Id }, createdVolumeRange);
        //}

    }
}
