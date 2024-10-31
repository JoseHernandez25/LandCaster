using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FinnancingParemeteres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinancingParameterId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinancingParameterId",
                table: "Hinges",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "HingeComponents",
                type: "Decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExternalAccesories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ExternalAccesories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

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
                name: "FinancingParameterId",
                table: "DrawerSlides",
                type: "int",
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

            migrationBuilder.CreateTable(
                name: "FinancingParametersTypes",
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
                    table.PrimaryKey("PK_FinancingParametersTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancingParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<float>(type: "real", nullable: false),
                    FinancingParametersTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancingParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancingParameters_FinancingParametersTypes_FinancingParametersTypeId",
                        column: x => x.FinancingParametersTypeId,
                        principalTable: "FinancingParametersTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FinancingParameterId",
                table: "Products",
                column: "FinancingParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Hinges_FinancingParameterId",
                table: "Hinges",
                column: "FinancingParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_DrawerSlides_FinancingParameterId",
                table: "DrawerSlides",
                column: "FinancingParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancingParameters_FinancingParametersTypeId",
                table: "FinancingParameters",
                column: "FinancingParametersTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancingParameters_Name",
                table: "FinancingParameters",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DrawerSlides_FinancingParameters_FinancingParameterId",
                table: "DrawerSlides",
                column: "FinancingParameterId",
                principalTable: "FinancingParameters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hinges_FinancingParameters_FinancingParameterId",
                table: "Hinges",
                column: "FinancingParameterId",
                principalTable: "FinancingParameters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FinancingParameters_FinancingParameterId",
                table: "Products",
                column: "FinancingParameterId",
                principalTable: "FinancingParameters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrawerSlides_FinancingParameters_FinancingParameterId",
                table: "DrawerSlides");

            migrationBuilder.DropForeignKey(
                name: "FK_Hinges_FinancingParameters_FinancingParameterId",
                table: "Hinges");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_FinancingParameters_FinancingParameterId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "FinancingParameters");

            migrationBuilder.DropTable(
                name: "FinancingParametersTypes");

            migrationBuilder.DropIndex(
                name: "IX_Products_FinancingParameterId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Hinges_FinancingParameterId",
                table: "Hinges");

            migrationBuilder.DropIndex(
                name: "IX_DrawerSlides_FinancingParameterId",
                table: "DrawerSlides");

            migrationBuilder.DropColumn(
                name: "FinancingParameterId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FinancingParameterId",
                table: "Hinges");

            migrationBuilder.DropColumn(
                name: "FinancingParameterId",
                table: "DrawerSlides");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "HingeComponents",
                type: "Decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(38,17)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExternalAccesories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ExternalAccesories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

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
