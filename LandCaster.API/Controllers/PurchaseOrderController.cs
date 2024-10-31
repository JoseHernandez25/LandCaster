using LandCaster.BLL;
using LandCaster.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public PurchaseOrderController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<PurchaseOrderController>
        [HttpGet, Authorize]
        public async Task<IEnumerable<PurchaseOrder>>Get()
        {
            return await _manageLogic.PurchaseOrder.GetPurchaseOrderAsync();
        }

        // GET api/<PurchaseOrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PurchaseOrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PurchaseOrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PurchaseOrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
