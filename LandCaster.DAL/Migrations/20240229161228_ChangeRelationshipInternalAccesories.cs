using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationshipInternalAccesories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_InternalAccesories_InternalAccesoryId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_InternalAccesoryId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "InternalAccesoryId",
                table: "Materials");

            migrationBuilder.AddColumn<int>(
                name: "SubTypeMaterialId",
                table: "InternalAccesories",
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

            migrationBuilder.CreateIndex(
                name: "IX_InternalAccesories_SubTypeMaterialId",
                table: "InternalAccesories",
                column: "SubTypeMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_InternalAccesories_SubTypeMaterials_SubTypeMaterialId",
                table: "InternalAccesories",
                column: "SubTypeMaterialId",
                principalTable: "SubTypeMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternalAccesories_SubTypeMaterials_SubTypeMaterialId",
                table: "InternalAccesories");

            migrationBuilder.DropIndex(
                name: "IX_InternalAccesories_SubTypeMaterialId",
                table: "InternalAccesories");

            migrationBuilder.DropColumn(
                name: "SubTypeMaterialId",
                table: "InternalAccesories");

            migrationBuilder.AddColumn<int>(
                name: "InternalAccesoryId",
                table: "Materials",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Materials_InternalAccesoryId",
                table: "Materials",
                column: "InternalAccesoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_InternalAccesories_InternalAccesoryId",
                table: "Materials",
                column: "InternalAccesoryId",
                principalTable: "InternalAccesories",
                principalColumn: "Id");
        }
    }
}
