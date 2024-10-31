using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandCaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Employees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Factories_FactoryId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Informationable_InformationableId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Stores_StoreId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Users_UserId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Employee_EmployeeId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_UserId",
                table: "Employees",
                newName: "IX_Employees_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_StoreId",
                table: "Employees",
                newName: "IX_Employees_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_InformationableId",
                table: "Employees",
                newName: "IX_Employees_InformationableId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_FactoryId",
                table: "Employees",
                newName: "IX_Employees_FactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Code",
                table: "Employees",
                newName: "IX_Employees_Code");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Factories_FactoryId",
                table: "Employees",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Informationable_InformationableId",
                table: "Employees",
                column: "InformationableId",
                principalTable: "Informationable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Stores_StoreId",
                table: "Employees",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Employees_EmployeeId",
                table: "Events",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Factories_FactoryId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Informationable_InformationableId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Stores_StoreId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Employees_EmployeeId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_UserId",
                table: "Employee",
                newName: "IX_Employee_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_StoreId",
                table: "Employee",
                newName: "IX_Employee_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_InformationableId",
                table: "Employee",
                newName: "IX_Employee_InformationableId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_FactoryId",
                table: "Employee",
                newName: "IX_Employee_FactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_Code",
                table: "Employee",
                newName: "IX_Employee_Code");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Factories_FactoryId",
                table: "Employee",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Informationable_InformationableId",
                table: "Employee",
                column: "InformationableId",
                principalTable: "Informationable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Stores_StoreId",
                table: "Employee",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Users_UserId",
                table: "Employee",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Employee_EmployeeId",
                table: "Events",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
