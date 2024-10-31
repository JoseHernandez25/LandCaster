using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Migrations;
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
    public class FactoryLogic : IFactoryLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public FactoryLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<PaginationResponse<Factory>> GetFactoryAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var factories = _unitOfWork.Factory.PaginateGetAsync(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "City,Suppliers,Employees",
            isTracking: false
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(factories, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<Factory> AddFactoryAsync(Factory factory)
        {
            var createFactory = _unitOfWork.Factory.Create(factory);
            await _unitOfWork.Save();

            return factory;
        }

        public async Task<Factory> UpdateFactoryAsync(int id, Factory factory)
        {
            _unitOfWork.Factory.Update(factory);
            await _unitOfWork.Save();
            return factory;
        }

        public async Task<Factory> DeleteFactoryAsync(int id)
        {
            var factory = await _unitOfWork.Factory.Find(id);

            factory.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Factory.Update(factory);
            await _unitOfWork.Save();
            return factory;
        }
    }
}
