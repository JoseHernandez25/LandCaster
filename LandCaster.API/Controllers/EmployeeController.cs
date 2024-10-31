using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entitites.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public EmployeeController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }

        //// GET: api/<EmployeeController>
        //[HttpGet]
        //public async Task<IEnumerable<Employee>>Get()
        //{
        //    return await _manageLogic.Employee.GetEmployeeAsync();
        //}

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet, Authorize]
        public async Task<PaginationResponse<Employee>> Get(
              int pageNumber,
              int pageSize,
              string? term,
              string? orderByAsc = null,
              string? orderBy = null
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

            if (orderByAsc != null)
                parameters.Parameters.Add("orderByAsc", orderByAsc);

            if (orderBy != null)
                parameters.Parameters.Add("orderBy", orderBy);

            return await _manageLogic.Employee.GetEmployeeAsync(parameters);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Post(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("El Objeto distribuidor es Nulo");
            }

            var createdEmployee = await _manageLogic.Employee.AddEmployeeAsync(employee);

            return CreatedAtAction("Get", new { id = createdEmployee.Id }, createdEmployee);
        }
        // PUT api/<EmployeeController>

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("El objeto empleado es nulo");
            }
            var createdEmployee = await _manageLogic.Employee.UpdateEmployeeAsync(id, employee);
            return CreatedAtAction("Get", new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var createdEmployee = await _manageLogic.Employee.DeleteEmployeeAsync(id);
            return CreatedAtAction("Get", new { Id = createdEmployee.Id }, createdEmployee);
        }
    }
}
