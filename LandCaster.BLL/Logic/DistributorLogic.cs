using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class DistributorLogic : IDistributorLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public DistributorLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<Distributor>> GetDistributorAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<Distributor>, IOrderedQueryable<Distributor>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");
            bool? withTrashed = parameters.Parameters.ContainsKey("withTrashed") ?
                (bool.TryParse(parameters.Parameters["withTrashed"].ToString(), out bool parsedValue) ? parsedValue : (bool?)null)
                : (bool?)true;

            Func<IQueryable<Distributor>, IOrderedQueryable<Distributor>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                 _ => null
            };

            orderBy = value;
            var distributors = _unitOfWork.Distributor.PaginateGetAsync(
              parameters: parameters,
              orderBy: orderBy,
              relationships: "",
              isTracking: false,
              withTrashed: withTrashed == null ? true : Convert.ToBoolean(withTrashed)
          );

            var paginationResponse =await PaginationHelper.CreatePaginationResponse(distributors, parameters.PageNumber);

            return paginationResponse;

        }



        public async Task<Distributor> AddDistributorAsync(Distributor distributor)
        {

            var createColor = _unitOfWork.Distributor.Create(distributor);
            await _unitOfWork.Save();

            return distributor;
        }
        public async Task<Distributor> UpdateDistributorAsync(int id, Distributor distributor)
        {
            _unitOfWork.Distributor.Update(distributor);
            await _unitOfWork.Save();
            return distributor;
        }

        public async Task<Distributor> DeleteDistributorAsync(int id)
        {
            var distributor = await _unitOfWork.Distributor.Find(id);

            distributor.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Distributor.Update(distributor);
            await _unitOfWork.Save();
            return distributor;
        }
    }
}
