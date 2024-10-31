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
    public interface IFinancingParameterLogic
    {
        Task<List<FinancingParameter>> GetFinancingParameterAsync();
        Task<FinancingParameter> AddFinancingParameterAsync(FinancingParameter financingParameter);
        Task<FinancingParameter> UpdateFinancingParameterAsync(int id, FinancingParameter financingParameter);
        Task<FinancingParameter> DeleteFinancingParameterAsync(int id);
    }
}

