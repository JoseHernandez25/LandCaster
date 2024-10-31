using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class EmployeeRepository  : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _context.Employees
                                 .ToListAsync();
            return employees;
        }
    }
}
