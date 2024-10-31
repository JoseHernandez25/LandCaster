using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL;
using LandCaster.DAL.Repository;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entitites.Entities;
using Microsoft.EntityFrameworkCore;

namespace LandCaster.BLL.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUnitOfWork _unitOfWork;


        public UserLogic(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<PaginationResponse<User>> GetUserAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            var roleId = parameters.Parameters.ContainsKey("roleId") ? Convert.ToString(parameters.Parameters["roleId"]) : (string)null;
            Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");

            Func<IQueryable<User>, IOrderedQueryable<User>>? value = orderByField switch
            {
                "username" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(u => u.UserName) : query.OrderByDescending(u => u.UserName),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(u => u.Id) : query.OrderByDescending(u => u.Id),
                "role" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(u => u.Role.NormalizedName) : query.OrderByDescending(u => u.Role.NormalizedName),
                _ => null
            };

            orderBy = value;
            var users = _unitOfWork.User.PaginateGetAsync(
                parameters: parameters,
                filter: h =>
                      (string.IsNullOrEmpty(term) || h.UserName.Contains(term)),
                orderBy: value,
                relationships: "Role",
                isTracking: false

            );
            var paginationResponse = await PaginationHelper.CreatePaginationResponse(users, parameters.PageNumber);
            return paginationResponse;
        }

        public async Task<User> AddUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "El usuario es nulo.");
            }

            if (user.RoleId == 4)
            {
                var employee = new Employee
                {
                    // Asigna las propiedades del empleado según sea necesario
                    Name = user.UserName,
                    Code = GenerateUniqueEmployeeCode(),
                    Status = 0,
                    Address = "sdfdf",
                    BirthDate = DateTime.Now,
                    CURP = "dsfdsf",
                    NSS = "sdf",
                    RFC = "sdds",
                    Telephone = user.PhoneNumber,
                };
                await _unitOfWork.Employee.Create(employee);
                await _unitOfWork.Save();
                employee.UserId = user.Id;
                user.Employee = employee;
            }
            if (user.RoleId == 3)
            {
                var distributor = new Distributor
                {
                    // Asigna las propiedades del empleado según sea necesario
                    Name = user.UserName,
                };
                await _unitOfWork.Distributor.Create(distributor);
                await _unitOfWork.Save();
                distributor.UserId = user.Id;
                user.Distributor = distributor;
            }

            // Agrega el usuario a la base de datos
            await  _unitOfWork.User.Create(user);
            await _unitOfWork.Save();

            return user;
        }

        public async Task<User> DeleteUserAsync(string id)
        {
            var user = await _unitOfWork.User.Finds(id);
            user.DeletedAt = DateTime.UtcNow;
            _unitOfWork.User.Update(user);
            await _unitOfWork.Save();
            return user;
        }

        public async Task<User> UpdateUserAsync(string id, User user)
        {
            _unitOfWork.User.Update(user);
            await _unitOfWork.Save();
            return user;
        }
        private int GenerateUniqueEmployeeCode()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 9999);
        }
    }

}


