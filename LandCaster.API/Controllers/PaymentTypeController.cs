using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/payment-type")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public PaymentTypeController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;
        }

        // GET: api/<PaymentTypeController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<PaymentType>> Get(int pageNumber, int pageSize, string? term)
        {
            var parameters = new PaginationDTO
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Parameters = new Dictionary<string, object>()
            };

            if (term != null)
                parameters.Parameters.Add("term", term);


            return await _manageLogic.PaymentType.GetPaymentTypeAsync(parameters);
        }

        // GET: api/<PaymentTypeController>
        [HttpGet("{id}"), Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<PaymentTypeController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(PaymentType PaymentType)
        {
            if (PaymentType == null)
            {
                return BadRequest("El Objeto otro accesorio es Nulo");
            }
            var createdPaymentType = await _manageLogic.PaymentType.AddPaymentTypeAsync(PaymentType);

            return CreatedAtAction("Get", new { id = createdPaymentType.Id }, createdPaymentType);
        }

        // PUT api/<PaymentTypeController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, PaymentType PaymentType)
        {
            if (PaymentType == null)
            {
                return BadRequest("El Objeto otro accesorio es Nulo");
            }
            var createdPaymentType = await _manageLogic.PaymentType.UpdatPaymentTypeAsync(id, PaymentType);

            return CreatedAtAction("Get", new { id = createdPaymentType.Id }, createdPaymentType);

        }

        // DELETE api/<PaymentTypeController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdPaymentType = await _manageLogic.PaymentType.DeletePaymentTypeAsync(id);

            return CreatedAtAction("Get", new { id = createdPaymentType.Id }, createdPaymentType);

        }
    }
}
