using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {       
        private readonly ApplicationDbContext _context;
 
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            Employee = new EmployeeRepository(_context);
            Hinge = new HingeRepository(_context);
            DrawerSlide = new DrawerSlideRepository(_context);
            Inventory = new InventoryRepository(_context);
            Category = new CategoryRepository(_context);
            SubCategory = new SubCategoryRepository(_context);
            SubSubCategory = new SubSubCategoryRepository(_context);
            Product = new ProductRepository(_context);
            PurchaseOrder = new PurchaseOrderRepository(_context);
            PurchaseOrderDetail = new PurchaseOrderDetailRepository(_context);
            ProductEvent = new ProductEventRepository(_context);
            ProductEventDetail = new ProductEventDetailRepository(_context);
            HingeComponent = new HingeComponentRepository(_context);
            DrawerSlideComponent = new DrawerSlideComponentRepository(_context);
            Angle = new AngleRepository(_context);
            HingeType = new HingeTypeRepository(_context);
            DrawerSlideType = new DrawerSlideTypeRepository(_context);
            MaterialType = new MaterialTypeRepository(_context);
            Material = new MaterialRepository(_context);
            Currencie = new CurrencieRepository(_context);
            Unit = new UnitRepository(_context);

            Color = new ColorRepository(_context);
            SubTypeMaterial = new SubTypeMaterialRepository(_context);
            Line = new LineRepository(_context);
            Area = new AreaRepository(_context);
            Role = new RoleRepository(_context);
            Route = new RouteRepository(_context);
            Joinery = new JoineryRepository(_context);
            JoineryType = new JoineryTypeRepository(_context);
            Model = new ModelRepository(_context);
            DoorModel = new DoorModelRepository(_context);
            TypesBoxJourney = new  TypesBoxJourneyRepository(_context);
            Distributor = new DistributorRepository(_context);
            ExternalAccessory = new ExternalAccessoryRepository(_context);
            Brand = new BrandRepository(_context);
            HingeHingeComponent = new HingeHingeComponentRepository(_context);
            AccesorieType = new AccesorieTypeRepository(_context);
            FinancingParamater = new FinancingParamaterRepository(_context);
            Supplier = new SupplierRepository(_context);
            DawerSlideDrwsComponent = new DrawerSlideDrwsComponentRepository(_context);
            DoorType = new DoorTypeRepository(_context);
            Factory = new FactoryRepository(_context);
            Furniture = new FurnitureRepository(_context);
            Insert = new InsertRepository(_context);
            DoorModelInsert = new DoorModelInsertRepository(_context); 
            DrillBit = new DrillBitRepository(_context);
            TongueGroove = new TongueGrooveRepository(_context);
            Molding = new MoldingRepository(_context);
            Profile = new ProfileRepository(_context);
            CenterType = new CenterTypeRepository(_context);
            Finish = new FinishRepository(_context);
            DoorModelInsert = new DoorModelInsertRepository(_context);
            VolumeRange = new VolumeRangeRepository(_context);
            DiscountType = new DiscountTypeRepository(_context);
            PaymentType = new PaymentTypeRepository(_context);
            Group = new GroupRepository(_context);


        }

        public IUserRepository User { get; private set; }

        public IEmployeeRepository Employee {get; private set; }
        public IHingeRepository Hinge { get; private set; }
        public IDistributorRepository Distributor { get; private set; }
        public IDrawerSlideRepository DrawerSlide { get; private set; }
        public IHingeComponentRepository HingeComponent { get; private set; }
        public IInventoryRepository Inventory { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public ISubCategoryRepository SubCategory { get; private set; }
        public ISubSubCategoryRepository SubSubCategory { get; private set; }
        public IProductRepository Product { get; private set; }
        public IPurchaseOrderRepository PurchaseOrder { get; private set; }
        public IPurchaseOrderDetailRepository PurchaseOrderDetail { get; private set; }
        public IProductEventRepository ProductEvent { get; private set; }
        public IProductEventDetailRepository ProductEventDetail { get; private set; }
        public IColorRepository Color { get; private set; }
        public ISubTypeMaterialRepository SubTypeMaterial { get; private set; }

        public IDrawerSlideComponentRepository DrawerSlideComponent { get; private set; }
        public IAngleRepository Angle {  get; private set; }
        public IHingeTypeRepository HingeType { get; private set; }
        public IDrawerSlideTypeRepository DrawerSlideType { get; }
        public IMaterialTypeRepository MaterialType { get; private set; }
        public ILineRepository Line { get; private set; }
        public IMaterialRepository Material { get; private set; }
        public IAreaRepository Area { get; private set; }
        public IRoleRepository Role { get; private set; }
        public IRouteRepository Route { get; private set; }
        public IJoineryRepository Joinery { get; private set; }
        public IJoineryTypeRepository JoineryType { get; private set; }
        public IModelRepository Model { get; private set; }
        public IDoorModelRepository DoorModel { get; private set; }
        public ICurrencieRepository currencie { get; private set; }
        public IUnitRepository unit { get; private set; }
        public ITypesBoxJourneyRepository TypesBoxJourney { get; private set; }
        public ICurrencieRepository Currencie { get; private set; }
        public IUnitRepository Unit { get; private set; }
        public IExternalAccessoryRepository ExternalAccessory { get; private set; }
        public IBrandRepository Brand { get; private set; }
        public IHingeHingeComponentRepository HingeHingeComponent { get; private set; }
        public IAccesorieTypeRepository AccesorieType { get; private set; }
        public IFinancingParamaterRepository FinancingParamater { get; private set; }
        public ISupplierRepository Supplier { get; private set; }

        public IFactoryRepository Factory { get; private set; }
        public IDrawerSlideDrwsComponentRepository DawerSlideDrwsComponent { get; private set; }
        public IFurnitureRepository Furniture { get; private set; }
        public IDoorTypeRepository DoorType { get; private set; }
        public IInsertRepository Insert { get; private set; }
        public IDoorModelInsertRepository DoorModelInsert {  get; private set; }
        public IDrillBitRepository DrillBit { get; private set; }
        public ITongueGrooveRepository TongueGroove { get; private set; }
        public IMoldingRepository Molding { get; private set; }
        public IProfileRepository Profile { get; private set; }
        public ICenterTypeRepository CenterType { get; private set; }
        public IFinishRepository Finish { get; private set; }
        public IVolumeRangeRepository VolumeRange { get; private set; }
        public IDiscountTypeRepository DiscountType { get; private set; }
        public IPaymentTypeRepository PaymentType { get; private set; }

        public IGroupRepository Group { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
           await _context.SaveChangesAsync();

        }
    }
}
