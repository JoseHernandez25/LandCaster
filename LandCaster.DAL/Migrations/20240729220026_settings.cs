using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class settings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Increment",
                table: "Finishes");

            migrationBuilder.RenameColumn(
                name: "CostPerLliter",
                table: "Finishes",
                newName: "FinishIFDoors");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "JoineryTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "HingeComponents",
                type: "Decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)");

            migrationBuilder.AddColumn<decimal>(
                name: "FinishIFAcc",
                table: "Finishes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.AddColumn<double>(
                name: "BoardLeakInH",
                table: "DoorModels",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BoardLeakInW",
                table: "DoorModels",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BootomFrameWidthInW",
                table: "DoorModels",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CenterTypeId",
                table: "DoorModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DoorLeakInH",
                table: "DoorModels",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DoorLeakInW",
                table: "DoorModels",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Dovetail",
                table: "DoorModels",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EditGolaModel",
                table: "DoorModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "ExteriorTrim",
                table: "DoorModels",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GolaHandle",
                table: "DoorModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MoldingId",
                table: "DoorModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PolishedWear",
                table: "DoorModels",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "DoorModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "StripPlate",
                table: "DoorModels",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TongueGrooveId",
                table: "DoorModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TopFrameWidtInW",
                table: "DoorModels",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WideFrameInH",
                table: "DoorModels",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentValue",
                table: "Currencies",
                type: "Decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)");

            migrationBuilder.CreateTable(
                name: "CenterTypes",
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
                    table.PrimaryKey("PK_CenterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrillBits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Path = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillBits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moldings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Path = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moldings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Path = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TongueGrooves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Path = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongueGrooves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoorModelDrillBit",
                columns: table => new
                {
                    DoorModelsId = table.Column<int>(type: "int", nullable: false),
                    DrillBitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorModelDrillBit", x => new { x.DoorModelsId, x.DrillBitsId });
                    table.ForeignKey(
                        name: "FK_DoorModelDrillBit_DoorModels_DoorModelsId",
                        column: x => x.DoorModelsId,
                        principalTable: "DoorModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoorModelDrillBit_DrillBits_DrillBitsId",
                        column: x => x.DrillBitsId,
                        principalTable: "DrillBits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JoineryTypes_Code",
                table: "JoineryTypes",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DoorModels_CenterTypeId",
                table: "DoorModels",
                column: "CenterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorModels_MoldingId",
                table: "DoorModels",
                column: "MoldingId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorModels_ProfileId",
                table: "DoorModels",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorModels_TongueGrooveId",
                table: "DoorModels",
                column: "TongueGrooveId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorModelDrillBit_DrillBitsId",
                table: "DoorModelDrillBit",
                column: "DrillBitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoorModels_CenterTypes_CenterTypeId",
                table: "DoorModels",
                column: "CenterTypeId",
                principalTable: "CenterTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoorModels_Moldings_MoldingId",
                table: "DoorModels",
                column: "MoldingId",
                principalTable: "Moldings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoorModels_Profiles_ProfileId",
                table: "DoorModels",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoorModels_TongueGrooves_TongueGrooveId",
                table: "DoorModels",
                column: "TongueGrooveId",
                principalTable: "TongueGrooves",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoorModels_CenterTypes_CenterTypeId",
                table: "DoorModels");

            migrationBuilder.DropForeignKey(
                name: "FK_DoorModels_Moldings_MoldingId",
                table: "DoorModels");

            migrationBuilder.DropForeignKey(
                name: "FK_DoorModels_Profiles_ProfileId",
                table: "DoorModels");

            migrationBuilder.DropForeignKey(
                name: "FK_DoorModels_TongueGrooves_TongueGrooveId",
                table: "DoorModels");

            migrationBuilder.DropTable(
                name: "CenterTypes");

            migrationBuilder.DropTable(
                name: "DoorModelDrillBit");

            migrationBuilder.DropTable(
                name: "Moldings");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "TongueGrooves");

            migrationBuilder.DropTable(
                name: "DrillBits");

            migrationBuilder.DropIndex(
                name: "IX_JoineryTypes_Code",
                table: "JoineryTypes");

            migrationBuilder.DropIndex(
                name: "IX_DoorModels_CenterTypeId",
                table: "DoorModels");

            migrationBuilder.DropIndex(
                name: "IX_DoorModels_MoldingId",
                table: "DoorModels");

            migrationBuilder.DropIndex(
                name: "IX_DoorModels_ProfileId",
                table: "DoorModels");

            migrationBuilder.DropIndex(
                name: "IX_DoorModels_TongueGrooveId",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "JoineryTypes");

            migrationBuilder.DropColumn(
                name: "FinishIFAcc",
                table: "Finishes");

            migrationBuilder.DropColumn(
                name: "BoardLeakInH",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "BoardLeakInW",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "BootomFrameWidthInW",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "CenterTypeId",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "DoorLeakInH",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "DoorLeakInW",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "Dovetail",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "EditGolaModel",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "ExteriorTrim",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "GolaHandle",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "MoldingId",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "PolishedWear",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "StripPlate",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "TongueGrooveId",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "TopFrameWidtInW",
                table: "DoorModels");

            migrationBuilder.DropColumn(
                name: "WideFrameInH",
                table: "DoorModels");

            migrationBuilder.RenameColumn(
                name: "FinishIFDoors",
                table: "Finishes",
                newName: "CostPerLliter");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "HingeComponents",
                type: "Decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(38,17)");

            migrationBuilder.AddColumn<string>(
                name: "Increment",
                table: "Finishes",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

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
