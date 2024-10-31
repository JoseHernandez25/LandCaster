using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public async Task<IEnumerable<Employee>> GetEmployeeAsync()
        //{
        //    var employees = await _unitOfWork.Employee.Get(
        //        filter: null,
        //        orderBy: null,
        //        properties: "Events,User,ProductEvents", // Agrega la propiedad User a las propiedades incluidas
        //        isTracking: true
        //    );
        //    return employees;
        //}
        public async Task<PaginationResponse<Employee>> GetEmployeeAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<Employee>, IOrderedQueryable<Employee>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");
            bool? withTrashed = parameters.Parameters.ContainsKey("withTrashed") ?
                (bool.TryParse(parameters.Parameters["withTrashed"].ToString(), out bool parsedValue) ? parsedValue : (bool?)null)
                : (bool?)true;

            Func<IQueryable<Employee>, IOrderedQueryable<Employee>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                _ => null
            };

            orderBy = value;
            var employees = _unitOfWork.Employee.PaginateGetAsync(
              parameters: parameters,
              orderBy: orderBy,
              relationships: "",
              isTracking: false,
              withTrashed: withTrashed == null ? true : Convert.ToBoolean(withTrashed)
          );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(employees, parameters.PageNumber);

            return paginationResponse;

        }



        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {

            var createColor = _unitOfWork.Employee.Create(employee);
            await _unitOfWork.Save();

            return employee;
        }
        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            _unitOfWork.Employee.Update(employee);
            await _unitOfWork.Save();
            return employee;
        }

        public async Task<Employee> DeleteEmployeeAsync(int id)
        {
            var employee = await _unitOfWork.Employee.Find(id);

            employee.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Employee.Update(employee);
            await _unitOfWork.Save();
            return employee;
        }

    }
}
