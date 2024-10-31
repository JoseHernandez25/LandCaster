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
    public class PaymentTypeLogic : IPaymentTypeLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentTypeLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<PaymentType>> GetPaymentTypeAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<PaymentType>, IOrderedQueryable<PaymentType>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");


            Func<IQueryable<PaymentType>, IOrderedQueryable<PaymentType>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                _ => null
            };




            orderBy = value;
            var PaymentTypes = _unitOfWork.PaymentType.PaginateGetAsync(
                parameters: parameters,
                filter: h =>
                      (string.IsNullOrEmpty(term) || h.Name.Contains(term)),
                orderBy: orderBy,
                relationships: "",
                isTracking: false
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(PaymentTypes, parameters.PageNumber);

            return paginationResponse;

        }

        public async Task<PaymentType> AddPaymentTypeAsync(PaymentType PaymentType)
        {

            var createPaymentType = _unitOfWork.PaymentType.Create(PaymentType);
            await _unitOfWork.Save();

            return PaymentType;
        }
        public async Task<PaymentType> UpdatPaymentTypeAsync(int id, PaymentType PaymentType)
        {
            _unitOfWork.PaymentType.Update(PaymentType);
            await _unitOfWork.Save();
            return PaymentType;
        }

        public async Task<PaymentType> DeletePaymentTypeAsync(int id)
        {
            var PaymentType = await _unitOfWork.PaymentType.Find(id);

            PaymentType.DeletedAt = DateTime.UtcNow;
            _unitOfWork.PaymentType.Update(PaymentType);
            await _unitOfWork.Save();
            return PaymentType;
        }


    }
}
