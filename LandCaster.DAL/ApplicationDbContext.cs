using LandCaster.Entities.Entities;
using LandCaster.Entitites.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace LandCaster.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Role>(entity => entity.ToTable(name: "Roles"));

            builder.Entity<User>(entity => entity.ToTable(name: "Users"));
            //builder.Entity<IdentityRole>(entity => entity.ToTable(name: "Roles"));
            builder.Entity<IdentityUserClaim<int>>(entity => entity.ToTable(name: "UsersClaims"));
            builder.Entity<IdentityRoleClaim<int>>(entity => entity.ToTable(name: "RolesClaims"));
            builder.Entity<IdentityUserLogin<int>>(entity => entity.ToTable(name: "Logins"));
            builder.Entity<IdentityUserToken<int>>(entity => entity.ToTable(name: "Tokens"));
            builder.Ignore<IdentityUserRole<int>>();

        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Angle> Angles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Currencie> Currencies  { get; set; }
        public DbSet<DrawerSlide> DrawerSlides { get; set; }
        public DbSet<DrawerSlideComponent> DrawerSlideComponents { get; set; }
        public DbSet<DrawerSlideType> DrawerSlideTypes { get; set; }
        public DbSet<Hinge> Hinges { get; set; }
        public DbSet<HingeComponent> HingeComponents { get; set; }
        public DbSet<HingeType> HingeTypes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Joinery> Joineries { get; set; }
        public DbSet<JoineryType> JoineryTypes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<SubTypeMaterial> SubTypeMaterials { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Finish> Finishes { get; set; }
        public DbSet<InternalAccessory> InternalAccessories { get; set; }
        public DbSet<Glasse> Glasses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SubSubCategory> SubSubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<ProductEvent> ProductEvents { get; set; }
        public DbSet<ProductEventDetail> ProductEventDetails { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<AreaRoute> AreaRoute { get; set; }
        public DbSet<TypesBoxJourney> TypesBoxJournies { get; set; }
        public DbSet<DoorModel> DoorModels { get; set; }
        public DbSet<CenterType> CenterTypes { get; set; }


        public DbSet<ExternalAccessory> ExternalAccessories { get; set; }
        public DbSet<AccessoryType> AccessoryTypes { get; set; }
        public DbSet<FinancingParametersType> FinancingParametersTypes { get; set; }

        public DbSet<FinancingParameter> FinancingParameters { get; set; }
        public DbSet<HingeHingeComponent> HingeHingeComponent { get; set; }
        public DbSet<DrawerSlideDrwsComponent> DrawerSlideDrwsComponent { get; set; }
        public DbSet<SupplierCredit> SupplierCredits { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<FurnitureAccessory> FurnitureAccessory { get; set; }
        public DbSet<MaterialInternalAccessory> MaterialInternalAccessory { get; set; }
        public DbSet<LandCasterProduct> LandCasterProducts { get; set; }
        public DbSet<InternalAccessoryType> InternalAccessoryTypes { get; set; }
        public DbSet<Drawer> Drawers { get; set; }
        public DbSet<DoorType> DoorTypes { get; set; }
        public DbSet<Insert> Inserts { get; set; }
        public DbSet<DoorModelInsert> DoorModelInsert { get; set; }
        public DbSet<DrillBit> DrillBits { get; set; }
        public DbSet<TongueGroove> TongueGrooves { get; set; }
        public DbSet<Molding> Moldings { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<DrawerSlideForQuotation> DrawerSlideForQuotations { get; set; }
        public DbSet<HingesForQuotation> HingesForQuotations { get; set; }
        public DbSet<StructureType> StructureTypes { get; set; }
        public DbSet<Structure> Structures { get; set; }
        public DbSet<FurnitureStructure> FurnitureStructure { get; set; }
        public DbSet<MaterialStructure> MaterialStructure { get; set; }
        public DbSet<VolumeRange> VolumeRanges { get; set; }
        public DbSet<DiscountType> DiscountTypes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMaterial> GroupMaterials { get; set; }




        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddTimestamps();
            return base.SaveChangesAsync();
        }


        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is TimeStamp && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var mexicoTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
            var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, mexicoTimeZone);

            foreach (var entity in entities)
            {
                var timeStampEntity = (TimeStamp)entity.Entity;

                if (entity.State == EntityState.Added)
                {
                    timeStampEntity.CreatedAt = now;
                }

                timeStampEntity.UpdatedAt = now;
            }
        }


    }
} 
