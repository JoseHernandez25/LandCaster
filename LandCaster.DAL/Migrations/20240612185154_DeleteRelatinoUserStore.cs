using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DeleteRelatinoUserStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Users_UserId",
                table: "Stores");

          
            migrationBuilder.DropIndex(
                name: "IX_Stores_UserId",
                table: "Stores");

           

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Stores");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.CreateIndex(
                name: "IX_Stores_UserId",
                table: "Stores",
                column: "UserId");


            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Users_UserId",
                table: "Stores",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

        }
    }
}
