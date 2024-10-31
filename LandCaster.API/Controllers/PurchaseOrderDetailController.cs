using LandCaster.BLL;
using LandCaster.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderDetailController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public PurchaseOrderDetailController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<PurchaseOrderDetailController>
        [HttpGet, Authorize]
        public async Task<IEnumerable<PurchaseOrderDetail>>Get()
        {
            return await _manageLogic.PurchaseOrderDetail.GetPurchaseOrderDetailAsync();
        }

        // GET api/<PurchaseOrderDetailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PurchaseOrderDetailController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PurchaseOrderDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PurchaseOrderDetailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
