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
    public interface IPaymentTypeLogic
    {
        Task<PaginationResponse<PaymentType>> GetPaymentTypeAsync(PaginationDTO parameters);
        Task<PaymentType> AddPaymentTypeAsync(PaymentType PaymentType);
        Task<PaymentType> UpdatPaymentTypeAsync(int id, PaymentType PaymentType);
        Task<PaymentType> DeletePaymentTypeAsync(int id);
    }
}
