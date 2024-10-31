using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.Hinges;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entities.Specfications;
using System.Linq;

namespace LandCaster.BLL.Logic
{
    public class FinancingParameterLogic : IFinancingParameterLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public FinancingParameterLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<FinancingParameter>> GetFinancingParameterAsync()
        {
            var financingParamaters = await _unitOfWork.FinancingParamater.Get();

            return financingParamaters;
        }

        public Task<FinancingParameter> AddFinancingParameterAsync(FinancingParameter financingParameter)
        {
            throw new NotImplementedException();
        }

        public Task<FinancingParameter> DeleteFinancingParameterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FinancingParameter> UpdateFinancingParameterAsync(int id, FinancingParameter financingParameter)
        {
            throw new NotImplementedException();
        }
    }
}


