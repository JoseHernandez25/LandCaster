using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Accesorie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubGroupId",
                table: "Materials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "AccesorieTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccesorieTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalAccesories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    IncreaseFactor = table.Column<double>(type: "float", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrencieId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    AccesorieTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalAccesories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalAccesories_AccesorieTypes_AccesorieTypeId",
                        column: x => x.AccesorieTypeId,
                        principalTable: "AccesorieTypes",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalAccesories");

            migrationBuilder.DropTable(
                name: "AccesorieTypes");

            migrationBuilder.AlterColumn<int>(
                name: "SubGroupId",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
