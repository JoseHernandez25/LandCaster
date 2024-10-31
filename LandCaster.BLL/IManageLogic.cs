using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL
{
    public interface IManageLogic
    {
        IUserLogic User { get; }

        IEmployeeLogic Employee { get; }
        IHingeLogic Hinge { get; }
        IDrawerSlideLogic DrawerSlide { get; }
        IInventoryLogic Inventory { get; }
        ICategoryLogic Category { get; }
        ISubCategoryLogic SubCategory { get; }
        ISubSubCategoryLogic SubSubCategory { get; }
        IProductLogic Product { get; }
        IPurchaseOrderLogic PurchaseOrder { get; }
        IPurchaseOrderDetailLogic PurchaseOrderDetail { get; }
        IProductEventLogic ProductEvent { get; }
        IProductEventDetailLogic ProductEventDetail { get; }
        IHingeComponentLogic HingeComponent { get; }
        IDrawerSlideComponentLogic DrawerSlideComponent { get; }
        IAngleLogic Angle { get; }
        IHingeTypeLogic HingeType { get; }
        IDrawerSlideTypeLogic DrawerSlideType { get; }
        IColorLogic Color { get; }
        ISubTypeMaterialLogic SubTypeMaterial { get; }
        IMaterialTypeLogic MaterialType { get; }
        ILineLogic Line { get; }
        IMaterialLogic Material { get; }
        IAreaLogic Area { get; }
        IRouteLogic Route { get; }
        IJoineryLogic Joinery { get; }
        IJoineryTypeLogic JoineryType { get; }
        IModelLogic Model { get; }
        IDoorModelLogic DoorModel { get; }
        ITypesBoxJourneyLogic TypesBoxJourney { get; }

        IRoleLogic Role { get; }
        IDistributorLogic Distributor { get; }
        ICurrencieLogic Currencie { get; }
        IUnitLogic Unit { get; }
        IBrandLogic Brand { get; }

        ICurrencieLogic currencie { get; }
        IUnitLogic unit { get; }

        IExternalAccessoryLogic ExternalAccessory { get; }
        IAccesorieTypeLogic AccesorieType { get; }
        IFinancingParameterLogic FinancingParameter { get; }

        ISupplierLogic Supplier { get; }
        IFactoryLogic Factory { get; }
        IFurnitureLogic Furniture { get; }
        IDoorTypeLogic DoorType { get; }
        IInsertLogic Insert { get; }
        IDrillBitLogic DrillBit { get; }
        ITongueGrooveLogic TongueGroove { get; }
        IMoldingLogic Molding { get; }
        IProfileLogic Profile { get; }
        ICenterTypeLogic CenterType { get; }
        IFinishLogic Finish {  get; }
        IVolumeRangeLogic VolumeRange { get; }
        IPaymentTypeLogic PaymentType { get; }
        IGroupLogic Group { get; }
    }
}
