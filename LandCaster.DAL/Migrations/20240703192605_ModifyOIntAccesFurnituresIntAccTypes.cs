using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModifyOIntAccesFurnituresIntAccTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FifthNomenclature",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "FourthNomenclature",
                table: "Furnitures");

            migrationBuilder.RenameColumn(
                name: "width",
                table: "Furnitures",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "height",
                table: "Furnitures",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "depth",
                table: "Furnitures",
                newName: "Depth");

            migrationBuilder.RenameColumn(
                name: "ThirdNomenclature",
                table: "Furnitures",
                newName: "SpecialNomenclature");

            migrationBuilder.RenameColumn(
                name: "HasLnearMeters",
                table: "Furnitures",
                newName: "HasLinearMeters");

            migrationBuilder.AddColumn<int>(
                name: "InternalAccessoryTypeId",
                table: "InternalAccessories",
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
                name: "InternalAccessoryTypes",
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
                    table.PrimaryKey("PK_InternalAccessoryTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternalAccessories_InternalAccessoryTypeId",
                table: "InternalAccessories",
                column: "InternalAccessoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InternalAccessories_InternalAccessoryTypes_InternalAccessoryTypeId",
                table: "InternalAccessories",
                column: "InternalAccessoryTypeId",
                principalTable: "InternalAccessoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternalAccessories_InternalAccessoryTypes_InternalAccessoryTypeId",
                table: "InternalAccessories");

            migrationBuilder.DropTable(
                name: "InternalAccessoryTypes");

            migrationBuilder.DropIndex(
                name: "IX_InternalAccessories_InternalAccessoryTypeId",
                table: "InternalAccessories");

            migrationBuilder.DropColumn(
                name: "InternalAccessoryTypeId",
                table: "InternalAccessories");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "Furnitures",
                newName: "width");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "Furnitures",
                newName: "height");

            migrationBuilder.RenameColumn(
                name: "Depth",
                table: "Furnitures",
                newName: "depth");

            migrationBuilder.RenameColumn(
                name: "SpecialNomenclature",
                table: "Furnitures",
                newName: "ThirdNomenclature");

            migrationBuilder.RenameColumn(
                name: "HasLinearMeters",
                table: "Furnitures",
                newName: "HasLnearMeters");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "HingeComponents",
                type: "Decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(38,17)");

            migrationBuilder.AddColumn<string>(
                name: "FifthNomenclature",
                table: "Furnitures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FourthNomenclature",
                table: "Furnitures",
                type: "nvarchar(max)",
                nullable: true);

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
