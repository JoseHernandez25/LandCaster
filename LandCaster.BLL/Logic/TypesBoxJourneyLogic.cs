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
    public class TypesBoxJouneryLogic : ITypesBoxJourneyLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypesBoxJouneryLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<TypesBoxJourney>> GetTypesBoxJourneyAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var typesBoxJourney = _unitOfWork.TypesBoxJourney.PaginateGetAsync(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "DoorModels",
                isTracking: false
            );


            var paginationResponse = await PaginationHelper.CreatePaginationResponse(typesBoxJourney, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<TypesBoxJourney> AddTypesBoxJourneyAsync(AddTypesBoxJourneyDTO addTypesBoxourneryDTO)

        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var created = await _unitOfWork.TypesBoxJourney.AddTypesBoxJourneyAsync(addTypesBoxourneryDTO);
            await _unitOfWork.Save();

            return created;
        }

        public async Task<TypesBoxJourney> UpdateTypesBoxJourneyAsync(int id, TypesBoxJourney typesBoxJourney)
        {
            _unitOfWork.TypesBoxJourney.Update(typesBoxJourney);
            await _unitOfWork.Save();
            return typesBoxJourney;
        }

        public async Task<TypesBoxJourney> DeleteTypesBoxJourneyAsync(int id)
        {
            var typesBoxJourney = await _unitOfWork.TypesBoxJourney.Find(id);

            typesBoxJourney.DeletedAt = DateTime.UtcNow;
            _unitOfWork.TypesBoxJourney.Update(typesBoxJourney);
            await _unitOfWork.Save();
            return typesBoxJourney;
        }
    }
}
