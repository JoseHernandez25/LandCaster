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
    public class ModelLogic : IModelLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModelLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<Model>> GetModelAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var models = _unitOfWork.Model.PaginateGetAsync(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "DoorModels",
            isTracking: false
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(models, parameters.PageNumber);

            return paginationResponse;
        }


        public async Task<Model> AddModelAsync(Model model)
        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var createModel = _unitOfWork.Model.Create(model);
            await _unitOfWork.Save();

            return model;
        }

        public async Task<Model> UpdateModelAsync(int id, Model model)
        {
            _unitOfWork.Model.Update(model);
            await _unitOfWork.Save();
            return model;
        }

        public async Task<Model> DeleteModelAsync(int id)
        {
            var model = await _unitOfWork.Model.Find(id);

            model.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Model.Update(model);
            await _unitOfWork.Save();
            return model;
        }
    }
}
