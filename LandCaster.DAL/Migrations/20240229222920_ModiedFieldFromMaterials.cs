using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModiedFieldFromMaterials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrawerSlideComponents_Brands_BrandId",
                table: "DrawerSlideComponents");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "States",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "CurrienciesId",
                table: "HingeComponents",
                newName: "CurriencieId");

            migrationBuilder.RenameColumn(
                name: "BrandsId",
                table: "HingeComponents",
                newName: "BrandId");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Events",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Countries",
                newName: "UpdateAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Units",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Units",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Units",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Suppliers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Suppliers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Suppliers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Stores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Stores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Stores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "States",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "HingeTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "HingeTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "HingeTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Hinges",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Hinges",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Hinges",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Hinges",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "HingeComponents",
                type: "Decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "HingeComponents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "HingeComponents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "HingeComponents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Finishes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Factories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Factories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Factories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Events",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DrawerSlideTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "DrawerSlideTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "DrawerSlideTypes",
                type: "datetime2",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "DrawerSlides",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DrawerSlides",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "DrawerSlides",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "DrawerSlides",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "DrawerSlideComponents",
                type: "Decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DrawerSlideComponents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "DrawerSlideComponents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "DrawerSlideComponents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Discounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Discounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Discounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentValue",
                table: "Currencies",
                type: "Decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Currencies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Currencies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Currencies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Couriers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Couriers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Couriers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Colors",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Brands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Brands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Brands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Angles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Angles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Angles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hinges_BrandId",
                table: "Hinges",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_HingeComponents_BrandId",
                table: "HingeComponents",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_HingeComponents_CurriencieId",
                table: "HingeComponents",
                column: "CurriencieId");

            migrationBuilder.CreateIndex(
                name: "IX_DrawerSlides_BrandId",
                table: "DrawerSlides",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrawerSlideComponents_Brands_BrandId",
                table: "DrawerSlideComponents",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DrawerSlides_Brands_BrandId",
                table: "DrawerSlides",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HingeComponents_Brands_BrandId",
                table: "HingeComponents",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HingeComponents_Currencies_CurriencieId",
                table: "HingeComponents",
                column: "CurriencieId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hinges_Brands_BrandId",
                table: "Hinges",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrawerSlideComponents_Brands_BrandId",
                table: "DrawerSlideComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_DrawerSlides_Brands_BrandId",
                table: "DrawerSlides");

            migrationBuilder.DropForeignKey(
                name: "FK_HingeComponents_Brands_BrandId",
                table: "HingeComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_HingeComponents_Currencies_CurriencieId",
                table: "HingeComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_Hinges_Brands_BrandId",
                table: "Hinges");

            migrationBuilder.DropIndex(
                name: "IX_Hinges_BrandId",
                table: "Hinges");

            migrationBuilder.DropIndex(
                name: "IX_HingeComponents_BrandId",
                table: "HingeComponents");

            migrationBuilder.DropIndex(
                name: "IX_HingeComponents_CurriencieId",
                table: "HingeComponents");

            migrationBuilder.DropIndex(
                name: "IX_DrawerSlides_BrandId",
                table: "DrawerSlides");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "States");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "HingeTypes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "HingeTypes");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "HingeTypes");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Hinges");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Hinges");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Hinges");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Hinges");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "HingeComponents");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "HingeComponents");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "HingeComponents");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DrawerSlideTypes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "DrawerSlideTypes");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "DrawerSlideTypes");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "DrawerSlides");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DrawerSlides");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "DrawerSlides");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "DrawerSlides");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DrawerSlideComponents");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "DrawerSlideComponents");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "DrawerSlideComponents");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Couriers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Couriers");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Couriers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Angles");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Angles");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Angles");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "States",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CurriencieId",
                table: "HingeComponents",
                newName: "CurrienciesId");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "HingeComponents",
                newName: "BrandsId");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Events",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Countries",
                newName: "UpdatedAt");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "HingeComponents",
                type: "Decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(38,17)");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Finishes",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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
                name: "Code",
                table: "Colors",
                type: "int",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_DrawerSlideComponents_Brands_BrandId",
                table: "DrawerSlideComponents",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
