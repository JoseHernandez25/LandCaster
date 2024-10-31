using LandCaster.DAL.Repository;
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
    public interface ITypesBoxJourneyLogic
    {
        Task<PaginationResponse<TypesBoxJourney>> GetTypesBoxJourneyAsync(PaginationDTO parameters);
        Task<TypesBoxJourney> AddTypesBoxJourneyAsync(AddTypesBoxJourneyDTO addTypesJourneyDTO);

        Task<TypesBoxJourney> UpdateTypesBoxJourneyAsync(int id, TypesBoxJourney typeBoxJourney);
        Task<TypesBoxJourney> DeleteTypesBoxJourneyAsync(int id);
    }
}
