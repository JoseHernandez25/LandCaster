using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class doorTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "DoorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Image = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoorModelDoorType",
                columns: table => new
                {
                    DoorModelsId = table.Column<int>(type: "int", nullable: false),
                    DoorTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorModelDoorType", x => new { x.DoorModelsId, x.DoorTypesId });
                    table.ForeignKey(
                        name: "FK_DoorModelDoorType_DoorModels_DoorModelsId",
                        column: x => x.DoorModelsId,
                        principalTable: "DoorModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoorModelDoorType_DoorTypes_DoorTypesId",
                        column: x => x.DoorTypesId,
                        principalTable: "DoorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoorModelDoorType_DoorTypesId",
                table: "DoorModelDoorType",
                column: "DoorTypesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoorModelDoorType");

            migrationBuilder.DropTable(
                name: "DoorTypes");

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
