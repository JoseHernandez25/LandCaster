using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DoorsModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoorModel_Lines_LineId",
                table: "DoorModel");

            migrationBuilder.DropForeignKey(
                name: "FK_JoineryTypes_Joineries_JoinerieId",
                table: "JoineryTypes");

            migrationBuilder.DropIndex(
                name: "IX_JoineryTypes_JoinerieId",
                table: "JoineryTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoorModel",
                table: "DoorModel");

            migrationBuilder.DropColumn(
                name: "JoinerieId",
                table: "JoineryTypes");

            migrationBuilder.RenameTable(
                name: "DoorModel",
                newName: "DoorModels");

            migrationBuilder.RenameIndex(
                name: "IX_DoorModel_LineId",
                table: "DoorModels",
                newName: "IX_DoorModels_LineId");

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

            migrationBuilder.AlterColumn<int>(
                name: "LineId",
                table: "DoorModels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DoorModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "DoorModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JoineryId",
                table: "DoorModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JoineryTypeId",
                table: "DoorModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaterialTypeId",
                table: "DoorModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "DoorModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PrivateCatalog",
                table: "DoorModels",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PublicCatalog",
                table: "DoorModels",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "DoorModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "DoorModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoorModels",
                table: "DoorModels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "JoineryJoineryType",
                columns: table => new
                {
                    JoineriesId = table.Column<int>(type: "int", nullable: false),
                    JoineryTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoineryJoineryType", x => new { x.JoineriesId, x.JoineryTypesId });
                    table.ForeignKey(
                        name: "FK_JoineryJoineryType_Joineries_JoineriesId",
                        column: x => x.JoineriesId,
                        principalTable: "Joineries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JoineryJoineryType_JoineryTypes_JoineryTypesId",
                        column: x => x.JoineryTypesId,
                        principalTable: "JoineryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesBoxJournies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesBoxJournies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoorModelTypesBoxJourney",
                columns: table => new
                {
                    DoorModelsId = table.Column<int>(type: "int", nullable: false),
                    TypesBoxJourniesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorModelTypesBoxJourney", x => new { x.DoorModelsId, x.TypesBoxJourniesId });
                    table.ForeignKey(
                        name: "FK_DoorModelTypesBoxJourney_DoorModels_DoorModelsId",
                        column: x => x.DoorModelsId,
                        principalTable: "DoorModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoorModelTypesBoxJourney_TypesBoxJournies_TypesBoxJourniesId",
                        column: x => x.TypesBoxJourniesId,
                        principalTable: "TypesBoxJournies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoorModels_JoineryId",
                table: "DoorModels",
                column: "JoineryId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorModels_JoineryTypeId",
                table: "DoorModels",
                column: "JoineryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorModels_MaterialTypeId",
                table: "DoorModels",
                column: "MaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorModels_ModelId",
                table: "DoorModels",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorModels_RouteId",
                table: "DoorModels",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorModelTypesBoxJourney_TypesBoxJourniesId",
                table: "DoorModelTypesBoxJourney",
                column: "TypesBoxJourniesId");

            migrationBuilder.CreateIndex(
                name: "IX_JoineryJoineryType_JoineryTypesId",
                table: "JoineryJoineryType",
                column: "JoineryTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoorModels_Joineries_JoineryId",
                table: "DoorModels",
                column: "JoineryId",
                principalTable: "Joineries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoorModels_JoineryTypes_JoineryTypeId",
                table: "DoorModels",
                column: "JoineryTypeId",
                principalTable: "JoineryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoorModels_Lines_LineId",
                table: "DoorModels",
                column: "LineId",
                principalTable: "Lines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoorModels_MaterialTypes_MaterialTypeId",
                table: "DoorModels",
                column: "MaterialTypeId",
                principalTable: "MaterialTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoorModels_Model_ModelId",
                table: "DoorModels",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoorModels_Routes_RouteId",
                table: "DoorModels",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoorModels_Joineries_JoineryId",
                table: "DoorModels");

            migrationBuilder.DropForeignKey(
                name: "FK_DoorModels_JoineryTypes_JoineryTypeId",
                table: "DoorModels");

            migrationBuilder.DropForeignKey(
                name: "FK_DoorModels_Lines_LineId",
                table: "DoorModels");

            migrationBuilder.DropForeignKey(
                name: "FK_DoorModels_MaterialTypes_MaterialTypeId",
                table: "DoorModels");

            migrationBuilder.DropForeignKey(
                name: "FK_DoorModels_Model_ModelId",
                table: "DoorModels");

            migrationBuilder.DropForeignKey(
                name: "FK_DoorModels_Routes_RouteId",
                table: "DoorModels");

            migrationBuilder.DropTable(
                name: "DoorModelTypesBoxJourney");

            migrationBuilder.DropTable(
                name: "JoineryJoineryType");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "TypesBoxJournies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoorModels",
                table: "DoorModels");

            migrationBuilder.DropIndex(
                name: "IX_DoorModels_JoineryId",
                table: "DoorModels");

            migrationBuilder.DropIndex(
                name: "IX_DoorModels_JoineryTypeId",
                table: "DoorModels");

            migrationBuilder.DropIndex(
                name: "IX_DoorModels_MaterialTypeId",
                table: "DoorModels");

            migrationBuilder.DropIndex(
                name: "IX_DoorModels_ModelId",
                table: "DoorModels");

            migrationBuilder.DropIndex(
                name: "IX_DoorModels_RouteId",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "JoineryId",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "JoineryTypeId",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "MaterialTypeId",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "PrivateCatalog",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "PublicCatalog",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "DoorModels");

            migrationBuilder.RenameTable(
                name: "DoorModels",
                newName: "DoorModel");

            migrationBuilder.RenameIndex(
                name: "IX_DoorModels_LineId",
                table: "DoorModel",
                newName: "IX_DoorModel_LineId");

            migrationBuilder.AddColumn<int>(
                name: "JoinerieId",
                table: "JoineryTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AlterColumn<int>(
                name: "LineId",
                table: "DoorModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoorModel",
                table: "DoorModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_JoineryTypes_JoinerieId",
                table: "JoineryTypes",
                column: "JoinerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoorModel_Lines_LineId",
                table: "DoorModel",
                column: "LineId",
                principalTable: "Lines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JoineryTypes_Joineries_JoinerieId",
                table: "JoineryTypes",
                column: "JoinerieId",
                principalTable: "Joineries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
