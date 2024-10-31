using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class StrucureTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FurnitureHinge");


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
                name: "Drawers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: true),
                    Depth = table.Column<double>(type: "float", nullable: true),
                    DepthLinealMetters = table.Column<double>(type: "float", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureExternalAccessory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnitureId = table.Column<int>(type: "int", nullable: false),
                    ExternalAccessoryId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureExternalAccessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FurnitureExternalAccessory_ExternalAccessories_ExternalAccessoryId",
                        column: x => x.ExternalAccessoryId,
                        principalTable: "ExternalAccessories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FurnitureExternalAccessory_Furnitures_FurnitureId",
                        column: x => x.FurnitureId,
                        principalTable: "Furnitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HingesForQuotations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnitureId = table.Column<int>(type: "int", nullable: false),
                    HingeId = table.Column<int>(type: "int", nullable: false),
                    HingeTypeId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HingesForQuotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HingesForQuotations_Furnitures_FurnitureId",
                        column: x => x.FurnitureId,
                        principalTable: "Furnitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HingesForQuotations_Hinges_HingeId",
                        column: x => x.HingeId,
                        principalTable: "Hinges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StructureTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StructureTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawerSlideForQuotations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawerSlideId = table.Column<int>(type: "int", nullable: false),
                    DrawerId = table.Column<int>(type: "int", nullable: false),
                    DrawerSlideTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawerSlideForQuotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrawerSlideForQuotations_DrawerSlideTypes_DrawerSlideTypeId",
                        column: x => x.DrawerSlideTypeId,
                        principalTable: "DrawerSlideTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DrawerSlideForQuotations_DrawerSlides_DrawerSlideId",
                        column: x => x.DrawerSlideId,
                        principalTable: "DrawerSlides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DrawerSlideForQuotations_Drawers_DrawerId",
                        column: x => x.DrawerId,
                        principalTable: "Drawers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureDrawer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnitureId = table.Column<int>(type: "int", nullable: false),
                    DrawerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureDrawer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FurnitureDrawer_Drawers_DrawerId",
                        column: x => x.DrawerId,
                        principalTable: "Drawers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FurnitureDrawer_Furnitures_FurnitureId",
                        column: x => x.FurnitureId,
                        principalTable: "Furnitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Structures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NewCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Depth = table.Column<double>(type: "float", nullable: false),
                    StructureTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Structures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Structures_StructureTypes_StructureTypeId",
                        column: x => x.StructureTypeId,
                        principalTable: "StructureTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureStructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnitureId = table.Column<int>(type: "int", nullable: false),
                    StructureId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FurnitureStructure_Furnitures_FurnitureId",
                        column: x => x.FurnitureId,
                        principalTable: "Furnitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FurnitureStructure_Structures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialStructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    StructureId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialStructure_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialStructure_Structures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drawers_Code",
                table: "Drawers",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DrawerSlideForQuotations_DrawerId",
                table: "DrawerSlideForQuotations",
                column: "DrawerId");

            migrationBuilder.CreateIndex(
                name: "IX_DrawerSlideForQuotations_DrawerSlideId",
                table: "DrawerSlideForQuotations",
                column: "DrawerSlideId");

            migrationBuilder.CreateIndex(
                name: "IX_DrawerSlideForQuotations_DrawerSlideTypeId",
                table: "DrawerSlideForQuotations",
                column: "DrawerSlideTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureDrawer_DrawerId",
                table: "FurnitureDrawer",
                column: "DrawerId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureDrawer_FurnitureId",
                table: "FurnitureDrawer",
                column: "FurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureExternalAccessory_ExternalAccessoryId",
                table: "FurnitureExternalAccessory",
                column: "ExternalAccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureExternalAccessory_FurnitureId",
                table: "FurnitureExternalAccessory",
                column: "FurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureStructure_FurnitureId",
                table: "FurnitureStructure",
                column: "FurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureStructure_StructureId",
                table: "FurnitureStructure",
                column: "StructureId");

            migrationBuilder.CreateIndex(
                name: "IX_HingesForQuotations_FurnitureId",
                table: "HingesForQuotations",
                column: "FurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_HingesForQuotations_HingeId",
                table: "HingesForQuotations",
                column: "HingeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialStructure_MaterialId",
                table: "MaterialStructure",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialStructure_StructureId",
                table: "MaterialStructure",
                column: "StructureId");

            migrationBuilder.CreateIndex(
                name: "IX_Structures_Code",
                table: "Structures",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Structures_NewCode",
                table: "Structures",
                column: "NewCode",
                unique: true,
                filter: "[NewCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Structures_StructureTypeId",
                table: "Structures",
                column: "StructureTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrawerSlideForQuotations");

            migrationBuilder.DropTable(
                name: "FurnitureDrawer");

            migrationBuilder.DropTable(
                name: "FurnitureExternalAccessory");

            migrationBuilder.DropTable(
                name: "FurnitureStructure");

            migrationBuilder.DropTable(
                name: "HingesForQuotations");

            migrationBuilder.DropTable(
                name: "MaterialStructure");

            migrationBuilder.DropTable(
                name: "Drawers");

            migrationBuilder.DropTable(
                name: "Structures");

            migrationBuilder.DropTable(
                name: "StructureTypes");

            migrationBuilder.DropColumn(
                name: "HingeDimensionId",
                table: "Hinges");

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


        }
    }
}
