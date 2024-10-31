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
    public class CurrencieLogic : ICurrencieLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencieLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        
}
        public Task<List<Currencie>> GetCurrencieAsync()
        {
            
            var currencies = _unitOfWork.Currencie.Get();

            return currencies;
        }
        public async Task<Currencie> AddCurrencieAsync(Currencie Currencie)
        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var createCurrencie = _unitOfWork.Currencie.Create(Currencie);
            await _unitOfWork.Save();

            return Currencie;
        }
    }
}
