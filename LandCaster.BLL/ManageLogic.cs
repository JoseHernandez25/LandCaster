using LandCaster.BLL.ILogic;
using LandCaster.BLL.Logic;
using LandCaster.BLL;
using LandCaster.DAL.Repository;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.Entities;

public class ManageLogic : IManageLogic
{
    private readonly IUnitOfWork _unitOfWork;

    public ManageLogic(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        User = new UserLogic(_unitOfWork);
        Employee = new EmployeeLogic(_unitOfWork);
        Hinge = new HingeLogic(_unitOfWork);
        DrawerSlide = new DrawerSlideLogic(_unitOfWork);
        Inventory = new InventoryLogic(_unitOfWork);
        Category = new CategoryLogic(_unitOfWork);
        SubCategory = new SubCategoryLogic(_unitOfWork);
        SubSubCategory = new SubSubCategoryLogic(_unitOfWork);
        Product= new ProductLogic(_unitOfWork);
        PurchaseOrder = new PurchaseOrderLogic(_unitOfWork);
        PurchaseOrderDetail = new PurchaseOrderDetailLogic(_unitOfWork);
        ProductEvent = new ProductEventLogic(_unitOfWork);
        ProductEventDetail = new ProductEventDetailLogic(_unitOfWork);
        HingeComponent = new HingeComponentLogic(_unitOfWork);
        Employee = new EmployeeLogic(unitOfWork);
        Hinge = new HingeLogic(unitOfWork);
        DrawerSlide = new DrawerSlideLogic(unitOfWork);
        HingeComponent = new HingeComponentLogic(unitOfWork);
        DrawerSlideComponent = new DrawerSlideComponentLogic(unitOfWork);
        Angle = new AngleLogic(unitOfWork);
        HingeType = new HingeTypeLogic(unitOfWork);
        DrawerSlideType = new DrawerSlideTypeLogic(unitOfWork);
        SubTypeMaterial = new SubTypeMaterialLogic(_unitOfWork);
        Color = new ColorLogic(unitOfWork);
        MaterialType = new MaterialTypeLogic(_unitOfWork);
        Line = new LineLogic(_unitOfWork);
        Material = new MaterialLogic(unitOfWork);
        Area = new AreaLogic(unitOfWork);
        ////Role = new RoleLogic(unitOfWork);
        Route = new RouteLogic(unitOfWork);
        Joinery = new JoineryLogic(unitOfWork);
        JoineryType = new JoineryTypeLogic(unitOfWork);
        Model = new ModelLogic(unitOfWork);
        DoorModel = new DoorModelLogic(unitOfWork);
        Currencie = new CurrencieLogic(_unitOfWork);
        Unit = new UnitLogic(_unitOfWork);
        TypesBoxJourney = new TypesBoxJouneryLogic(_unitOfWork);
        Brand = new BrandLogic(_unitOfWork);

        ExternalAccessory = new ExternalAccessoryLogic(_unitOfWork);
        AccesorieType = new AccessoryTypeLogic(_unitOfWork);
        Supplier = new SupplierLogic(_unitOfWork);

        currencie = new CurrencieLogic(_unitOfWork);
        unit = new UnitLogic(_unitOfWork);
        Distributor = new DistributorLogic(unitOfWork);
        Factory = new FactoryLogic(unitOfWork);
        FinancingParameter = new FinancingParameterLogic(unitOfWork);
        Furniture = new FurnitureLogic(unitOfWork);
        DoorType = new DoorTypeLogic(unitOfWork);
        Insert = new InsertLogic(unitOfWork);
        DrillBit = new DrillBitLogic(unitOfWork);
        TongueGroove = new TongueGrooveLogic(unitOfWork);
        Molding = new MoldingLogic(unitOfWork);
        Profile = new ProfileLogic(unitOfWork);
        CenterType = new CenterTypeLogic(unitOfWork);
        Finish = new FinishLogic(unitOfWork);
        VolumeRange = new VolumeRangeLogic(unitOfWork);
        PaymentType = new PaymentTypeLogic(unitOfWork);
        Group = new GroupLogic(unitOfWork);

    }

    public IUserLogic User { get; private set; }
    public IEmployeeLogic Employee { get; private set; }
    public IHingeLogic Hinge { get; private set; }
    public IDrawerSlideLogic DrawerSlide { get; private set; }
    public IInventoryLogic Inventory { get; private set; }
    public ICategoryLogic Category { get; private set; }
    public ISubCategoryLogic SubCategory { get; private set; }
    public ISubSubCategoryLogic SubSubCategory { get; private set; }
    public IProductLogic Product { get; private set; }
    public IPurchaseOrderLogic PurchaseOrder { get; private set;}
    public IPurchaseOrderDetailLogic PurchaseOrderDetail { get; private set; }
    public IProductEventLogic ProductEvent { get; private set; }
    public IProductEventDetailLogic ProductEventDetail { get; private set; }
    public IHingeComponentLogic HingeComponent { get; private set; }
    public IColorLogic Color { get; private set; }
    public ISubTypeMaterialLogic SubTypeMaterial { get; private set; }
    public IDrawerSlideComponentLogic DrawerSlideComponent { get; private set; }
    public IAngleLogic Angle { get; private set; }
    public IHingeTypeLogic HingeType { get; private set; }
    public IDrawerSlideTypeLogic DrawerSlideType { get; private set; }
    public IMaterialTypeLogic MaterialType { get; private set; }
    public IMaterialLogic Material {  get; private set; }
    public ILineLogic Line { get; private set; }
    public IAreaLogic Area { get; private set; }
    public IRoleLogic Role { get; private set; }
    public IRouteLogic Route { get; private set; }
    public IJoineryLogic Joinery { get; private set; }
    public IJoineryTypeLogic JoineryType { get; private set; }
    public IModelLogic Model { get; private set; }
    public IDoorModelLogic DoorModel { get; private set; }
    public ICurrencieLogic Currencie { get; private set; }
    public IUnitLogic Unit { get; private set; }
    public ITypesBoxJourneyLogic TypesBoxJourney { get; private set; }
    public IBrandLogic Brand { get; private set; }
    public IExternalAccessoryLogic ExternalAccessory { get; private set; }

    public IAccesorieTypeLogic AccesorieType { get; private set; }
    public ISupplierLogic Supplier { get; private set; }
    public ICurrencieLogic currencie { get; private set; }
    public IUnitLogic unit { get; private set; }
    public IDistributorLogic Distributor { get; private set; }
    public IFinancingParameterLogic FinancingParameter { get; private set; }
    public IFactoryLogic Factory { get; private set; }
    public IFurnitureLogic Furniture { get; private set; }
    public IDoorTypeLogic DoorType { get; private set; }
    public IInsertLogic Insert { get; private set; }
          public IDrillBitLogic DrillBit { get; private set; }
    public ITongueGrooveLogic TongueGroove { get; private set; }
    public IMoldingLogic Molding { get; private set; }
    public IProfileLogic Profile { get; private set; }
    public ICenterTypeLogic CenterType { get; private set; }
    public IFinishLogic Finish { get; private set; }

    public IVolumeRangeLogic VolumeRange { get; private set; }
    public IPaymentTypeLogic PaymentType { get; private set; }
    public IGroupLogic Group { get; private set; }
}
