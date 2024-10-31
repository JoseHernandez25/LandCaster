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
    public class JoineryLogic : IJoineryLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public JoineryLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<Joinery>> GetJoineryAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var joineries = _unitOfWork.Joinery.PaginateGetAsync(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "JoineryTypes",
            isTracking: false
            );


            var paginationResponse = await PaginationHelper.CreatePaginationResponse(joineries, parameters.PageNumber);

            return paginationResponse;
        }


        public async Task<Joinery> AddJoineryAsync(AddJoineryDTO addJoineryDTO)

        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var created = await _unitOfWork.Joinery.AddJoineryAsync(addJoineryDTO);
            await _unitOfWork.Save();

            return created;
        }

        public async Task<Joinery> UpdateJoineryAsync(int id, Joinery joinery)
        {
            _unitOfWork.Joinery.Update(joinery);
            await _unitOfWork.Save();
            return joinery;
        }

        public async Task<Joinery> DeleteJoineryAsync(int id)
        {
            var joinery = await _unitOfWork.Joinery.Find(id);

            joinery.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Joinery.Update(joinery);
            await _unitOfWork.Save();
            return joinery;
        }
    }
}
