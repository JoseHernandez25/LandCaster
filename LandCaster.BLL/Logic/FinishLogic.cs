using LandCaster.BLL.helpers;
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
    public class FinishLogic : IFinishLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public FinishLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<Finish>> GetFinishAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var finish = _unitOfWork.Finish.PaginateGetAsync(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "SubTypeMaterials",
                isTracking: false
            );


            var paginationResponse = await PaginationHelper.CreatePaginationResponse(finish, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<Finish> AddFinishAsync(Finish finish)

        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var createdFinish = _unitOfWork.Finish.Create(finish);
            await _unitOfWork.Save();

            return finish;
        }

        public async Task<Finish> UpdateFinishAsync(int id, Finish finish)
        {
            _unitOfWork.Finish.Update(finish);
            await _unitOfWork.Save();
            return finish;
        }

        public async Task<Finish> DeleteFinishAsync(int id)
        {
            var finish = await _unitOfWork.Finish.Find(id);

            finish.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Finish.Update(finish);
            await _unitOfWork.Save();
            return finish;
        }
    }
}
