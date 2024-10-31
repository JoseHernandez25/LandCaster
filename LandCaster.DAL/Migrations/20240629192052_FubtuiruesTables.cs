using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FubtuiruesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalAccesories");

            migrationBuilder.DropTable(
                name: "InternalAccesories");

            migrationBuilder.DropTable(
                name: "AccesoryTypes");

            migrationBuilder.AddColumn<int>(
                name: "MaterialForAccessory",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "HingeComponents",
                type: "Decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "DrawerSlides",
                type: "Decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "DrawerSlides",
                type: "Decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "DrawerSlideComponents",
                type: "Decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentValue",
                table: "Currencies",
                type: "Decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)");

            migrationBuilder.CreateTable(
                name: "AccessoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Furnitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false),
                    height = table.Column<double>(type: "float", nullable: false),
                    width = table.Column<double>(type: "float", nullable: false),
                    depth = table.Column<double>(type: "float", nullable: false),
                    FirstNomenclature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondNomenclature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdNomenclature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthNomenclature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FifthNomenclature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaticHeight = table.Column<bool>(type: "bit", nullable: false),
                    StaticWidth = table.Column<bool>(type: "bit", nullable: false),
                    StaticDepth = table.Column<bool>(type: "bit", nullable: false),
                    IntegralFinish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatalogNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clearance = table.Column<double>(type: "float", nullable: false),
                    CodeHeight = table.Column<int>(type: "int", nullable: false),
                    CodeWidth = table.Column<int>(type: "int", nullable: false),
                    CodeDepth = table.Column<int>(type: "int", nullable: false),
                    InstalationCost = table.Column<double>(type: "float", nullable: false),
                    PackagingCosts = table.Column<double>(type: "float", nullable: false),
                    Shelves = table.Column<int>(type: "int", nullable: false),
                    Tops = table.Column<int>(type: "int", nullable: false),
                    Clasification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Screws = table.Column<int>(type: "int", nullable: false),
                    NumberOfLegs = table.Column<int>(type: "int", nullable: false),
                    DrawerPulls = table.Column<int>(type: "int", nullable: false),
                    DoorsPulls = table.Column<int>(type: "int", nullable: false),
                    HasLegs = table.Column<bool>(type: "bit", nullable: false),
                    HasSquareMeters = table.Column<bool>(type: "bit", nullable: false),
                    HasLnearMeters = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnitures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalAccessories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    height = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    width = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    depth = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    VarnishSquareMeters = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    FirstNomenclature = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    SecondNomenclature = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThirdNomenclature = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubTypeMaterialId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalAccessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalAccessories_SubTypeMaterials_SubTypeMaterialId",
                        column: x => x.SubTypeMaterialId,
                        principalTable: "SubTypeMaterials",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LandCasterProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandCasterProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalAccessories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SupplierKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    IncreaseFactor = table.Column<double>(type: "float", nullable: true),
                    CurrencieId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    AccesorieTypeId = table.Column<int>(type: "int", nullable: true),
                    FinancingParameterId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalAccessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalAccessories_AccessoryTypes_AccesorieTypeId",
                        column: x => x.AccesorieTypeId,
                        principalTable: "AccessoryTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExternalAccessories_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExternalAccessories_Currencies_CurrencieId",
                        column: x => x.CurrencieId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExternalAccessories_FinancingParameters_FinancingParameterId",
                        column: x => x.FinancingParameterId,
                        principalTable: "FinancingParameters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExternalAccessories_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FurnitureHinge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnitureId = table.Column<int>(type: "int", nullable: false),
                    HingeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureHinge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FurnitureHinge_Furnitures_FurnitureId",
                        column: x => x.FurnitureId,
                        principalTable: "Furnitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FurnitureHinge_Hinges_HingeId",
                        column: x => x.HingeId,
                        principalTable: "Hinges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureAccessory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnitureId = table.Column<int>(type: "int", nullable: false),
                    InternalAccessoryId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureAccessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FurnitureAccessory_Furnitures_FurnitureId",
                        column: x => x.FurnitureId,
                        principalTable: "Furnitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FurnitureAccessory_InternalAccessories_InternalAccessoryId",
                        column: x => x.InternalAccessoryId,
                        principalTable: "InternalAccessories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialInternalAccessory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    InternalAccessoryId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialInternalAccessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialInternalAccessory_InternalAccessories_InternalAccessoryId",
                        column: x => x.InternalAccessoryId,
                        principalTable: "InternalAccessories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialInternalAccessory_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureLandCasterProduct",
                columns: table => new
                {
                    FurnituresId = table.Column<int>(type: "int", nullable: false),
                    LandCasterProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureLandCasterProduct", x => new { x.FurnituresId, x.LandCasterProductsId });
                    table.ForeignKey(
                        name: "FK_FurnitureLandCasterProduct_Furnitures_FurnituresId",
                        column: x => x.FurnituresId,
                        principalTable: "Furnitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FurnitureLandCasterProduct_LandCasterProducts_LandCasterProductsId",
                        column: x => x.LandCasterProductsId,
                        principalTable: "LandCasterProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalAccessories_AccesorieTypeId",
                table: "ExternalAccessories",
                column: "AccesorieTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalAccessories_BrandId",
                table: "ExternalAccessories",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalAccessories_CurrencieId",
                table: "ExternalAccessories",
                column: "CurrencieId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalAccessories_FinancingParameterId",
                table: "ExternalAccessories",
                column: "FinancingParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalAccessories_SupplierId",
                table: "ExternalAccessories",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureAccessory_FurnitureId",
                table: "FurnitureAccessory",
                column: "FurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureAccessory_InternalAccessoryId",
                table: "FurnitureAccessory",
                column: "InternalAccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureHinge_FurnitureId",
                table: "FurnitureHinge",
                column: "FurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureHinge_HingeId",
                table: "FurnitureHinge",
                column: "HingeId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureLandCasterProduct_LandCasterProductsId",
                table: "FurnitureLandCasterProduct",
                column: "LandCasterProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_Code",
                table: "Furnitures",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InternalAccessories_SubTypeMaterialId",
                table: "InternalAccessories",
                column: "SubTypeMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialInternalAccessory_InternalAccessoryId",
                table: "MaterialInternalAccessory",
                column: "InternalAccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialInternalAccessory_MaterialId",
                table: "MaterialInternalAccessory",
                column: "MaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalAccessories");

            migrationBuilder.DropTable(
                name: "FurnitureAccessory");

            migrationBuilder.DropTable(
                name: "FurnitureHinge");

            migrationBuilder.DropTable(
                name: "FurnitureLandCasterProduct");

            migrationBuilder.DropTable(
                name: "MaterialInternalAccessory");

            migrationBuilder.DropTable(
                name: "AccessoryTypes");

            migrationBuilder.DropTable(
                name: "Furnitures");

            migrationBuilder.DropTable(
                name: "LandCasterProducts");

            migrationBuilder.DropTable(
                name: "InternalAccessories");

            migrationBuilder.DropColumn(
                name: "MaterialForAccessory",
                table: "Materials");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "HingeComponents",
                type: "Decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(38,17)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "DrawerSlides",
                type: "Decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(38,17)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "DrawerSlides",
                type: "Decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(38,17)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "DrawerSlideComponents",
                type: "Decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(38,17)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentValue",
                table: "Currencies",
                type: "Decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(38,17)");

            migrationBuilder.CreateTable(
                name: "AccesoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccesoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalAccesories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubTypeMaterialId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    FirstNomenclature = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    H = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    SecondNomenclature = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThirdNomenclature = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VarnishM2 = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    W = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Z = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalAccesories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalAccesories_SubTypeMaterials_SubTypeMaterialId",
                        column: x => x.SubTypeMaterialId,
                        principalTable: "SubTypeMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalAccesories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccesorieTypeId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    CurrencieId = table.Column<int>(type: "int", nullable: true),
                    FinancingParameterId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IncreaseFactor = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SupplierKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalAccesories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalAccesories_AccesoryTypes_AccesorieTypeId",
                        column: x => x.AccesorieTypeId,
                        principalTable: "AccesoryTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExternalAccesories_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExternalAccesories_Currencies_CurrencieId",
                        column: x => x.CurrencieId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExternalAccesories_FinancingParameters_FinancingParameterId",
                        column: x => x.FinancingParameterId,
                        principalTable: "FinancingParameters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExternalAccesories_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalAccesories_AccesorieTypeId",
                table: "ExternalAccesories",
                column: "AccesorieTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalAccesories_BrandId",
                table: "ExternalAccesories",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalAccesories_CurrencieId",
                table: "ExternalAccesories",
                column: "CurrencieId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalAccesories_FinancingParameterId",
                table: "ExternalAccesories",
                column: "FinancingParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalAccesories_SupplierId",
                table: "ExternalAccesories",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalAccesories_SubTypeMaterialId",
                table: "InternalAccesories",
                column: "SubTypeMaterialId");
        }
    }
}
