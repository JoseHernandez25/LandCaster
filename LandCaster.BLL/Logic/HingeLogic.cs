using LandCaster.BLL.helpers;
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
    public class HingeLogic : IHingeLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public HingeLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<PaginationResponse<Hinge>> GetHingeAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            var brandId = parameters.Parameters.ContainsKey("brandId") ? Convert.ToInt32 (parameters.Parameters["brandId"]) : (int?)null;
            var AngleId = parameters.Parameters.ContainsKey("angleId") ? Convert.ToInt32(parameters.Parameters["angleId"]) : (int?)null;
            var HingeTypeId = parameters.Parameters.ContainsKey("HingeTypeId") ? Convert.ToInt32(parameters.Parameters["HingeTypeId"]) : (int?)null;

            Func<IQueryable<Hinge>, IOrderedQueryable<Hinge>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");

            Func<IQueryable<Hinge>, IOrderedQueryable<Hinge>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "code" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Code) : query.OrderByDescending(c => c.Code),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                "brand" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Brand.Name) : query.OrderByDescending(c => c.Brand.Name),
                "angle" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Angle.Name) : query.OrderByDescending(c => c.Angle.Name),
                "HingeType" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.HingeType.Name) : query.OrderByDescending(c => c.HingeType.Name),


                _ => null
            };

            orderBy = value;
            var hinges = _unitOfWork.Hinge.PaginateGetAsync(
                parameters: parameters,
                filter: h =>
                      (string.IsNullOrEmpty(term) || h.Name.Contains(term) || h.Code.Contains(term)) &&
                    (!brandId.HasValue || (h.BrandId != null && h.BrandId == brandId)) &&                
                     (!AngleId.HasValue || (h.AngleId != null && h.AngleId == AngleId)) &&
                      (!HingeTypeId.HasValue || (h.HingeTypeId != null && h.HingeTypeId == HingeTypeId)),
                orderBy: orderBy,
                relationships: "HingeHingeComponents.Component.Brand,HingeType,Angle,Brand,FinancingParameter,HingeHingeComponents.Component.Currencie",
                isTracking: false
            );

            var paginationResponse =await PaginationHelper.CreatePaginationResponse(hinges, parameters.PageNumber);

            return paginationResponse;
        }


        public async Task<Hinge> AddHingeAsync(AddHingeDTO addHingeDTO)
        {

            var existingHinge = await _unitOfWork.Hinge.Fisrt(h => h.Code == addHingeDTO.Hinge.Code && h.HingeTypeId == addHingeDTO.Hinge.HingeTypeId);
            if (existingHinge != null)
            {
                throw new Exception();
            }
                   

            await _unitOfWork.Hinge.Create(addHingeDTO.Hinge);
            await _unitOfWork.Save();

            foreach (var component in addHingeDTO.Components)
            {
                var hingeHingeComponent = new HingeHingeComponent
                {
                    Quantity = component.Quantity,
                    ComponentId = component.ComponentId,
                    HingeId = addHingeDTO.Hinge.Id
                };

                await _unitOfWork.HingeHingeComponent.Create(hingeHingeComponent);
            }

            await _unitOfWork.Save();
            return addHingeDTO.Hinge;
        }

        public async Task<Hinge> UpdateHingeAsync(int id, UpdateHingeDTO updateHingeDTO)
        {
          
            var hingec = await _unitOfWork.Hinge.Fisrt(h => h.Id == id, isTracking: false);
            if (hingec == null)
            {
                throw new KeyNotFoundException("Hinge not found.");
            }

            // Verificar si el código o el tipo de hinge están siendo cambiados
            bool isCodeChanged = !hingec.Code.Equals(updateHingeDTO.Hinge.Code);
            bool isTypeChanged = hingec.HingeTypeId != updateHingeDTO.Hinge.HingeTypeId;

            if (isCodeChanged || isTypeChanged)
            {
                // Verificar si el nuevo código de hinge ya existe en el tipo de hinge especificado
                var existsHingeType = await _unitOfWork.HingeType.Fisrt(
                 filter: h => h.Id == updateHingeDTO.Hinge.HingeTypeId,
                 properties: "Hinges",
                 isTracking: false
                    );

                if (existsHingeType == null)
                {
                    throw new KeyNotFoundException("HingeType not found.");
                }

                var existsHinge = existsHingeType.Hinges.Any(h => h.Code == updateHingeDTO.Hinge.Code);

                if (existsHinge)
                {
                    throw new InvalidOperationException("A hinge with the same code already exists in the specified hinge type.");
                }
            }


            _unitOfWork.Hinge.Update(updateHingeDTO.Hinge);

            var hinge = await _unitOfWork.Hinge.Fisrt(
                         filter: h => h.Id == id,
                         properties: "HingeHingeComponents");

            foreach (var component in hinge.HingeHingeComponents)
            {
                _unitOfWork.HingeHingeComponent.Delete(component);
            }

            foreach (var component in updateHingeDTO.Components)
            {
                var hingeHingeComponent = new HingeHingeComponent();
                hingeHingeComponent.Quantity = component.Quantity;
                hingeHingeComponent.ComponentId = component.ComponentId;
                hingeHingeComponent.HingeId = hinge.Id;

                await _unitOfWork.HingeHingeComponent.Create(hingeHingeComponent);

            }
            await _unitOfWork.Save();
            return updateHingeDTO.Hinge;
        }

        public async Task<Hinge> DeleteHingeAsync(int id)
        {
            var hinge = await _unitOfWork.Hinge.Find(id);

            hinge.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Hinge.Update(hinge);
            await _unitOfWork.Save();
            return hinge;
        }

        public async Task<List<Brand>> GetBrands()
        {
            var brands = await _unitOfWork.Brand.Get();

            return brands;
        }
        public async Task<List<HingeType>> GetHingeTypes()
        {
           
            var hingeTypes = await _unitOfWork.HingeType.Get();

            return hingeTypes;
        }


        public async Task DeleteHingeComponentAsync(int hingeId, int componentId)
        {
 
            await _unitOfWork.Hinge.DeleteHingeComponentAsync(hingeId, componentId);

            await _unitOfWork.Save();
        }


        //var hingec = await _unitOfWork.Hinge.Fisrt(h => h.Id == id, isTracking: false);
        //bool isEquals = hingec.Code.Equals(updateHingeDTO.Hinge.Code);

        //if (!isEquals)
        //{
        //    var existsHingeType = await _unitOfWork.HingeType.Fisrt(
        //     filter: h => h.Id == updateHingeDTO.Hinge.HingeTypeId,
        //     properties: "Hinges",
        //     isTracking: false
        //        );
        //    var existsHinge = existsHingeType.Hinges.Where(h => h.Code == updateHingeDTO.Hinge.Code);
        //    //return updateHingeDTO.Hinge;
        //    if (existsHinge.Any())
        //    {
        //        throw new Exception();
        //    }
        //}


    }
}


