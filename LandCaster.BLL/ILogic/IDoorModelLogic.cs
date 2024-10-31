using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.DoorsModels;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.ILogic
{
    public interface IDoorModelLogic
    {
        Task<PaginationResponse<DoorModel>> GetDoorModelAsync(PaginationDTO parameters);

        Task<IEnumerable<Model>> GetModelAsync();
        Task<IEnumerable<MaterialType>> GetMaterialType();
        Task<IEnumerable<Joinery>> GetJoinery();
        Task<IEnumerable<JoineryType>> GetJoineryType();
        Task<IEnumerable<Route>> GetRoute();
        Task<IEnumerable<Line>> GetLine();
        Task<IEnumerable<TypesBoxJourney>> GetTypesBoxJourney();
        Task<IEnumerable<DoorType>> GetDoorType();
        Task<IEnumerable<CenterType>> GetCenterType();
        Task<IEnumerable<Molding>> GetMolding();

        Task<DoorModel> AddDoorModelAsync(AddDoorModelDTO addDoorModelDTO);

        Task<DoorModel> UpdateDoorModelAsync(int id, UpdateDoorModelDTO updateDoorModelDTO);
        Task<DoorModel> DeleteDoorModelAsync(int id);
    }
}
