﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Forte : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "ForteId",
                table: "DrawerSlideDrwsComponent",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxWidth",
                table: "DrawerSlideDrwsComponent",
                type: "float",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForteId",
                table: "DrawerSlideDrwsComponent");

            migrationBuilder.DropColumn(
                name: "MaxWidth",
                table: "DrawerSlideDrwsComponent");


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
