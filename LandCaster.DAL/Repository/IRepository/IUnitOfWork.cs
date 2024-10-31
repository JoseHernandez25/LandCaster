using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IEmployeeRepository Employee { get; }
        IHingeRepository Hinge { get; }
        IDrawerSlideRepository DrawerSlide { get; }
        IInventoryRepository Inventory { get; }
        ICategoryRepository Category { get; }
        ISubCategoryRepository SubCategory { get; }
        ISubSubCategoryRepository SubSubCategory { get; }
        IProductRepository Product { get; }
        IPurchaseOrderRepository PurchaseOrder { get; }
        IPurchaseOrderDetailRepository PurchaseOrderDetail { get; }
        IProductEventRepository ProductEvent { get; }
        IProductEventDetailRepository ProductEventDetail { get; }
        IHingeComponentRepository HingeComponent { get; }
        IDrawerSlideComponentRepository DrawerSlideComponent { get; }
        IAngleRepository Angle {  get; }
        IHingeTypeRepository HingeType { get; }
        IDrawerSlideTypeRepository DrawerSlideType { get; }
        IColorRepository Color { get; }   
        ISubTypeMaterialRepository SubTypeMaterial { get; }
        IMaterialTypeRepository MaterialType { get; }
        IMaterialRepository Material {  get; }
        ILineRepository Line { get; }
        IAreaRepository Area { get; }
        IRouteRepository Route { get; }
        IJoineryRepository Joinery { get; }
        IJoineryTypeRepository JoineryType { get; }
        IModelRepository Model { get; }
        IDoorModelRepository DoorModel { get; }
        ITypesBoxJourneyRepository TypesBoxJourney { get; }
        ICurrencieRepository Currencie { get; }
        IUnitRepository Unit { get; }
        IExternalAccessoryRepository ExternalAccessory { get; }
        IBrandRepository Brand { get; }

        IHingeHingeComponentRepository HingeHingeComponent { get; }
        IAccesorieTypeRepository AccesorieType { get; }
        ISupplierRepository Supplier { get; }
        IRoleRepository Role { get; }
        IDistributorRepository Distributor { get; }
        IFinancingParamaterRepository FinancingParamater { get; }

        IDrawerSlideDrwsComponentRepository DawerSlideDrwsComponent { get; }

        IFactoryRepository Factory { get; }
        IFurnitureRepository Furniture { get; }
        IDoorTypeRepository DoorType { get; }
        IInsertRepository Insert { get; }
        IDoorModelInsertRepository DoorModelInsert { get; }
        IDrillBitRepository DrillBit { get; }
        ITongueGrooveRepository TongueGroove { get; }
        IMoldingRepository Molding { get; }
        IProfileRepository Profile { get; } 
        ICenterTypeRepository CenterType { get; }
        IFinishRepository Finish { get; }
        IVolumeRangeRepository VolumeRange { get; }
        IDiscountTypeRepository DiscountType { get; }
        IPaymentTypeRepository PaymentType { get; }
        IGroupRepository Group { get; }


        Task Save();


    }
}
