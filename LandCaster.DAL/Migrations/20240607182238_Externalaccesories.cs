using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Externalaccesories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalAccesories_AccesorieTypes_AccesorieTypeId",
                table: "ExternalAccesories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccesorieTypes",
                table: "AccesorieTypes");

            migrationBuilder.RenameTable(
                name: "AccesorieTypes",
                newName: "AccesoryTypes");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "HingeComponents",
                type: "Decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)");

            migrationBuilder.AddColumn<int>(
                name: "FinancingParameterId",
                table: "ExternalAccesories",
                type: "int",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccesoryTypes",
                table: "AccesoryTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalAccesories_FinancingParameterId",
                table: "ExternalAccesories",
                column: "FinancingParameterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalAccesories_AccesoryTypes_AccesorieTypeId",
                table: "ExternalAccesories",
                column: "AccesorieTypeId",
                principalTable: "AccesoryTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalAccesories_FinancingParameters_FinancingParameterId",
                table: "ExternalAccesories",
                column: "FinancingParameterId",
                principalTable: "FinancingParameters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalAccesories_AccesoryTypes_AccesorieTypeId",
                table: "ExternalAccesories");

            migrationBuilder.DropForeignKey(
                name: "FK_ExternalAccesories_FinancingParameters_FinancingParameterId",
                table: "ExternalAccesories");

            migrationBuilder.DropIndex(
                name: "IX_ExternalAccesories_FinancingParameterId",
                table: "ExternalAccesories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccesoryTypes",
                table: "AccesoryTypes");

            migrationBuilder.DropColumn(
                name: "FinancingParameterId",
                table: "ExternalAccesories");

            migrationBuilder.RenameTable(
                name: "AccesoryTypes",
                newName: "AccesorieTypes");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccesorieTypes",
                table: "AccesorieTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalAccesories_AccesorieTypes_AccesorieTypeId",
                table: "ExternalAccesories",
                column: "AccesorieTypeId",
                principalTable: "AccesorieTypes",
                principalColumn: "Id");
        }
    }
}
