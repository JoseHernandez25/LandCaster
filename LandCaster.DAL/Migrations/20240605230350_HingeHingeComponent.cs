using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class HingeHingeComponent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HingeHingeComponent_HingeComponents_ComponentsId",
                table: "HingeHingeComponent");

            migrationBuilder.DropForeignKey(
                name: "FK_HingeHingeComponent_Hinges_HingesId",
                table: "HingeHingeComponent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HingeHingeComponent",
                table: "HingeHingeComponent");

            migrationBuilder.DropIndex(
                name: "IX_HingeHingeComponent_HingesId",
                table: "HingeHingeComponent");

            migrationBuilder.RenameColumn(
                name: "HingesId",
                table: "HingeHingeComponent",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "ComponentsId",
                table: "HingeHingeComponent",
                newName: "HingeId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HingeHingeComponent",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "HingeHingeComponent",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_HingeHingeComponent",
                table: "HingeHingeComponent",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HingeHingeComponent_ComponentId",
                table: "HingeHingeComponent",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_HingeHingeComponent_HingeId",
                table: "HingeHingeComponent",
                column: "HingeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HingeHingeComponent_HingeComponents_ComponentId",
                table: "HingeHingeComponent",
                column: "ComponentId",
                principalTable: "HingeComponents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HingeHingeComponent_Hinges_HingeId",
                table: "HingeHingeComponent",
                column: "HingeId",
                principalTable: "Hinges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HingeHingeComponent_HingeComponents_ComponentId",
                table: "HingeHingeComponent");

            migrationBuilder.DropForeignKey(
                name: "FK_HingeHingeComponent_Hinges_HingeId",
                table: "HingeHingeComponent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HingeHingeComponent",
                table: "HingeHingeComponent");

            migrationBuilder.DropIndex(
                name: "IX_HingeHingeComponent_ComponentId",
                table: "HingeHingeComponent");

            migrationBuilder.DropIndex(
                name: "IX_HingeHingeComponent_HingeId",
                table: "HingeHingeComponent");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HingeHingeComponent");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "HingeHingeComponent");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "HingeHingeComponent",
                newName: "HingesId");

            migrationBuilder.RenameColumn(
                name: "HingeId",
                table: "HingeHingeComponent",
                newName: "ComponentsId");

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
                name: "PK_HingeHingeComponent",
                table: "HingeHingeComponent",
                columns: new[] { "ComponentsId", "HingesId" });

            migrationBuilder.CreateIndex(
                name: "IX_HingeHingeComponent_HingesId",
                table: "HingeHingeComponent",
                column: "HingesId");

            migrationBuilder.AddForeignKey(
                name: "FK_HingeHingeComponent_HingeComponents_ComponentsId",
                table: "HingeHingeComponent",
                column: "ComponentsId",
                principalTable: "HingeComponents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HingeHingeComponent_Hinges_HingesId",
                table: "HingeHingeComponent",
                column: "HingesId",
                principalTable: "Hinges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
