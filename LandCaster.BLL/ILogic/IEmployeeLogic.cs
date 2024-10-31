using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.ILogic
{
    public interface IEmployeeLogic
    {
        //Task<IEnumerable<Employee>> GetEmployeeAsync();
        
        Task<PaginationResponse<Employee>> GetEmployeeAsync(PaginationDTO parameters);
        Task<Employee> AddEmployeeAsync(Employee Employee);
        Task<Employee> DeleteEmployeeAsync(int id);
        Task<Employee> UpdateEmployeeAsync(int id, Employee Employee);
    }
}
