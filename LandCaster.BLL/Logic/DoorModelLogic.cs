using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.DoorsModels;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class DoorModelLogic : IDoorModelLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoorModelLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<DoorModel>> GetDoorModelAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            var modelId = parameters.Parameters.ContainsKey("modelId") ? Convert.ToInt32(parameters.Parameters["modelId"]) : (int?)null;
            var lineId = parameters.Parameters.ContainsKey("lineId") ? Convert.ToInt32(parameters.Parameters["lineId"]) : (int?)null;
            var routeId = parameters.Parameters.ContainsKey("routeId") ? Convert.ToInt32(parameters.Parameters["routeId"]) : (int?)null;
            var joineryId = parameters.Parameters.ContainsKey("joineryId") ? Convert.ToInt32(parameters.Parameters["joineryId"]) : (int?)null;
            var joineryTypeId = parameters.Parameters.ContainsKey("joineryTypeId") ? Convert.ToInt32(parameters.Parameters["joineryTypeId"]) : (int?)null;
            var materialTypeId = parameters.Parameters.ContainsKey("materialTypeId") ? Convert.ToInt32(parameters.Parameters["materialTypeId"]) : (int?)null;
            Func<IQueryable<DoorModel>, IOrderedQueryable<DoorModel>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");
            bool? withTrashed = parameters.Parameters.ContainsKey("withTrashed") ?
                (bool.TryParse(parameters.Parameters["withTrashed"].ToString(), out bool parsedValue) ? parsedValue : (bool?)null)
                : (bool?)true;

            Func<IQueryable<DoorModel>, IOrderedQueryable<DoorModel>>? value = orderByField switch
            {
                "privateCatalog" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.PrivateCatalog) : query.OrderByDescending(c => c.PrivateCatalog),
                "publicCatalog" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.PublicCatalog) : query.OrderByDescending(c => c.PublicCatalog),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                "model" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Model.Name) : query.OrderByDescending(c => c.Model.Name),
                "line" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Line.Name) : query.OrderByDescending(c => c.Line.Name),
                "route" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Route.Description) : query.OrderByDescending(c => c.Route.Description),
                "joinery" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Joinery.Name) : query.OrderByDescending(c => c.Joinery.Name),
                "joineryType" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.JoineryType.Name) : query.OrderByDescending(c => c.JoineryType.Name),
                "materialType" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.MaterialType.Name) : query.OrderByDescending(c => c.MaterialType.Name),
                _ => null
            };



            orderBy = value;
            var doorModel = _unitOfWork.DoorModel.PaginateGetAsync(
              parameters: parameters,
              filter: h =>
                      ((string.IsNullOrEmpty(term) || h.Model.Name.Contains(term)) ||
                      (string.IsNullOrEmpty(term) || h.Joinery.Name.Contains(term)) ||
                      (string.IsNullOrEmpty(term) || h.JoineryType.Name.Contains(term)) ||
                      (string.IsNullOrEmpty(term) || h.Line.Name.Contains(term)) ||
                      (string.IsNullOrEmpty(term) || h.Route.Code.Contains(term)) ||
                      (string.IsNullOrEmpty(term) || h.MaterialType.Name.Contains(term))) &&
                      (!modelId.HasValue || h.ModelId == modelId) &&
                      (!materialTypeId.HasValue || h.MaterialTypeId == materialTypeId) &&
                      (!joineryId.HasValue || h.JoineryId == joineryId) &&
                      (!joineryTypeId.HasValue || h.JoineryTypeId == joineryTypeId) &&
                      (!routeId.HasValue || h.RouteId == routeId) &&
                      (!lineId.HasValue || h.LineId == lineId),
              orderBy: orderBy,
              relationships: "Model,Line,Route,JoineryType,Joinery,TypesBoxJournies,MaterialType,Materials,DoorTypes,DoorModelInserts.Insert",
              isTracking: false
              //withTrashed: withTrashed == null ? true : Convert.ToBoolean(withTrashed)
          );

            var paginationResponse =await PaginationHelper.CreatePaginationResponse(doorModel, parameters.PageNumber);

            return paginationResponse;
        }


        public async Task<IEnumerable<Model>> GetModelAsync()
        {
            var Model = await _unitOfWork.Model.Get(
                filter: null,
                orderBy: null,
                properties: "", // Agrega la propiedad Components a las propiedades incluidas
                isTracking: true
            );
            return Model;
        }

        public async Task<IEnumerable<MaterialType>> GetMaterialType()
        {
            var materialType = await _unitOfWork.MaterialType.Get(
                filter: null,
                orderBy: null,
                properties: "Materials", // Agrega la propiedad Components a las propiedades incluidas
                isTracking: true
            );
            return materialType;
        }
        public async Task<IEnumerable<Joinery>> GetJoinery()
        {
            var joinery = await _unitOfWork.Joinery.Get(
                filter: null,
                orderBy: null,
                properties: "JoineryTypes", // Agrega la propiedad Components a las propiedades incluidas
                isTracking: true
            );
            return joinery;
        }

        public async Task<IEnumerable<JoineryType>> GetJoineryType()
        {
            var joineryType = await _unitOfWork.JoineryType.Get(
                filter: null,
                orderBy: null,
                properties: "Joineries", // Agrega la propiedad Components a las propiedades incluidas
                isTracking: true
            );
            return joineryType;
        }
        public async Task<IEnumerable<Route>> GetRoute()
        {
            var routes = await _unitOfWork.Route.Get(
                filter: null,
                orderBy: null,
                properties: "", // Agrega la propiedad Components a las propiedades incluidas
                isTracking: true
            );
            return routes;
        }
        public async Task<IEnumerable<Line>> GetLine()
        {
            var line = await _unitOfWork.Line.Get(
                filter: null,
                orderBy: null,
                properties: "", // Agrega la propiedad Components a las propiedades incluidas
                isTracking: true
            );
            return line;
        }

        public async Task<IEnumerable<TypesBoxJourney>> GetTypesBoxJourney()
        {
            var typesBoxJourney = await _unitOfWork.TypesBoxJourney.Get(
                filter: null,
                orderBy: null,
                properties: "", // Agrega la propiedad Components a las propiedades incluidas
                isTracking: true
            );
            return typesBoxJourney;
        }

        public async Task<IEnumerable<DoorType>> GetDoorType()
        {
            var doorType = await _unitOfWork.DoorType.Get(
                filter: null,
                orderBy: null,
                properties: "", // Agrega la propiedad Components a las propiedades incluidas
                isTracking: true
            );
            return doorType;
        }
        public async Task<IEnumerable<CenterType>> GetCenterType()
        {
            var centerType = await _unitOfWork.CenterType.Get(
                filter: null,
                orderBy: null,
                properties: "", // Agrega la propiedad Components a las propiedades incluidas
                isTracking: true
            );
            return centerType;
        }
        public async Task<IEnumerable<Molding>> GetMolding()
        {
            var molding = await _unitOfWork.Molding.Get(
                filter: null,
                orderBy: null,
                properties: "", // Agrega la propiedad Components a las propiedades incluidas
                isTracking: true
            );
            return molding;
        }


        public async Task<DoorModel> AddDoorModelAsync(AddDoorModelDTO addDoorModelDTO)

        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var created = await _unitOfWork.DoorModel.AddDoorModelAsync(addDoorModelDTO);
            await _unitOfWork.Save();

            return created;
        }

        public async Task<DoorModel> UpdateDoorModelAsync(int id, UpdateDoorModelDTO updateDoorModelDTO)
        {
            // Obtener el DoorModel actual con sus relaciones cargadas
            var doorModel = await _unitOfWork.DoorModel.Fisrt(
                                filter: dm => dm.Id == id,
                                properties: "TypesBoxJournies,Materials,DoorTypes");

            if (doorModel == null)
            {
                throw new Exception("DoorModel not found.");
            }

            if (updateDoorModelDTO.DoorModel != null)
            {
                doorModel.PrivateCatalog = updateDoorModelDTO.DoorModel.PrivateCatalog;
                doorModel.PublicCatalog = updateDoorModelDTO.DoorModel.PublicCatalog;
                doorModel.ModelId = updateDoorModelDTO.DoorModel.ModelId;
                doorModel.JoineryId = updateDoorModelDTO.DoorModel.JoineryId;
                doorModel.JoineryTypeId = updateDoorModelDTO.DoorModel.JoineryTypeId;
                doorModel.LineId = updateDoorModelDTO.DoorModel.LineId;
                doorModel.RouteId = updateDoorModelDTO.DoorModel.RouteId;
                doorModel.MaterialTypeId = updateDoorModelDTO.DoorModel.MaterialTypeId;
            }

            // Eliminar todas las relaciones TypesBoxJourneys actuales del DoorModel
            doorModel.TypesBoxJournies.Clear();

            // Eliminar todas las relaciones Materials actuales del DoorModel
            doorModel.Materials.Clear();

            // Eliminar todas las relaciones Materials actuales del DoorModel
            doorModel.DoorTypes.Clear();

            // Obtener los nuevos TypesBoxJourneys basados en los IDs proporcionados en updateDoorModelDTO
            var typesBoxJournies = await _unitOfWork.TypesBoxJourney.Get(
                                            filter: tb => updateDoorModelDTO.TypesBoxJourneyIds.Contains(tb.Id));

            // Obtener los nuevos Materials basados en los IDs proporcionados en updateDoorModelDTO
            var materials = await _unitOfWork.Material.Get(
                                        filter: m => updateDoorModelDTO.MaterialIds.Contains(m.Id));

            // Obtener los nuevos Materials basados en los IDs proporcionados en updateDoorModelDTO
            var doorTypes = await _unitOfWork.DoorType.Get(
                                        filter: dt => updateDoorModelDTO.DoorTypeIds.Contains(dt.Id));

            // Agregar los nuevos TypesBoxJourneys al DoorModel
            foreach (var typesBoxJourney in typesBoxJournies)
            {
                doorModel.TypesBoxJournies.Add(typesBoxJourney);
            }

            // Agregar los nuevos Materials al DoorModel
            foreach (var material in materials)
            {
                doorModel.Materials.Add(material);
            }

            foreach (var doorType in doorTypes)
            {
                doorModel.DoorTypes.Add(doorType);
            }

            // Actualizar la entidad DoorModel en el contexto
            _unitOfWork.DoorModel.Update(doorModel);

            // Guardar los cambios en la base de datos
            await _unitOfWork.Save();

            return doorModel;
        }


        public async Task<DoorModel> DeleteDoorModelAsync(int id)
        {
            var doorModel = await _unitOfWork.DoorModel.Find(id);

            doorModel.DeletedAt = DateTime.UtcNow;
            _unitOfWork.DoorModel.Update(doorModel);
            await _unitOfWork.Save();
            return doorModel;
        }
    }
}
