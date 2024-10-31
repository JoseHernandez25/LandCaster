using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class HingesDrawerSlider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Angles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Iso = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    CurrentValue = table.Column<decimal>(type: "Decimal(38,17)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawerSlideTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawerSlideTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HingeComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(38,17)", nullable: false),
                    CurrienciesId = table.Column<int>(type: "int", nullable: false),
                    BrandsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HingeComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HingeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HingeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UnitType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawerSlides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(38,17)", nullable: false),
                    Cost = table.Column<decimal>(type: "Decimal(38,17)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DrawerSlideTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawerSlides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrawerSlides_DrawerSlideTypes_DrawerSlideTypeId",
                        column: x => x.DrawerSlideTypeId,
                        principalTable: "DrawerSlideTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hinges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AngleId = table.Column<int>(type: "int", nullable: false),
                    HingeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hinges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hinges_Angles_AngleId",
                        column: x => x.AngleId,
                        principalTable: "Angles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hinges_HingeTypes_HingeTypeId",
                        column: x => x.HingeTypeId,
                        principalTable: "HingeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrawerSlideComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cost = table.Column<decimal>(type: "Decimal(38,17)", nullable: false),
                    CurrencieId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawerSlideComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrawerSlideComponents_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrawerSlideComponents_Currencies_CurrencieId",
                        column: x => x.CurrencieId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrawerSlideComponents_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HingeHingeComponent",
                columns: table => new
                {
                    ComponentsId = table.Column<int>(type: "int", nullable: false),
                    HingesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HingeHingeComponent", x => new { x.ComponentsId, x.HingesId });
                    table.ForeignKey(
                        name: "FK_HingeHingeComponent_HingeComponents_ComponentsId",
                        column: x => x.ComponentsId,
                        principalTable: "HingeComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HingeHingeComponent_Hinges_HingesId",
                        column: x => x.HingesId,
                        principalTable: "Hinges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrawerSlideDrawerSlideComponent",
                columns: table => new
                {
                    ComponentsId = table.Column<int>(type: "int", nullable: false),
                    DrawerSlidesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawerSlideDrawerSlideComponent", x => new { x.ComponentsId, x.DrawerSlidesId });
                    table.ForeignKey(
                        name: "FK_DrawerSlideDrawerSlideComponent_DrawerSlideComponents_ComponentsId",
                        column: x => x.ComponentsId,
                        principalTable: "DrawerSlideComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrawerSlideDrawerSlideComponent_DrawerSlides_DrawerSlidesId",
                        column: x => x.DrawerSlidesId,
                        principalTable: "DrawerSlides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrawerSlideComponents_BrandId",
                table: "DrawerSlideComponents",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_DrawerSlideComponents_CurrencieId",
                table: "DrawerSlideComponents",
                column: "CurrencieId");

            migrationBuilder.CreateIndex(
                name: "IX_DrawerSlideComponents_UnitId",
                table: "DrawerSlideComponents",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_DrawerSlideDrawerSlideComponent_DrawerSlidesId",
                table: "DrawerSlideDrawerSlideComponent",
                column: "DrawerSlidesId");

            migrationBuilder.CreateIndex(
                name: "IX_DrawerSlides_DrawerSlideTypeId",
                table: "DrawerSlides",
                column: "DrawerSlideTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HingeHingeComponent_HingesId",
                table: "HingeHingeComponent",
                column: "HingesId");

            migrationBuilder.CreateIndex(
                name: "IX_Hinges_AngleId",
                table: "Hinges",
                column: "AngleId");

            migrationBuilder.CreateIndex(
                name: "IX_Hinges_HingeTypeId",
                table: "Hinges",
                column: "HingeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrawerSlideDrawerSlideComponent");

            migrationBuilder.DropTable(
                name: "HingeHingeComponent");

            migrationBuilder.DropTable(
                name: "DrawerSlideComponents");

            migrationBuilder.DropTable(
                name: "DrawerSlides");

            migrationBuilder.DropTable(
                name: "HingeComponents");

            migrationBuilder.DropTable(
                name: "Hinges");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "DrawerSlideTypes");

            migrationBuilder.DropTable(
                name: "Angles");

            migrationBuilder.DropTable(
                name: "HingeTypes");

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
