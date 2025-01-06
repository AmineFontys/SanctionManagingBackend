using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SanctionManagingBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSanction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_Employees_CreatedById",
                table: "Sanctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_SanctionTypes_SanctionTypeId",
                table: "Sanctions");

            migrationBuilder.DropIndex(
                name: "IX_Sanctions_CreatedById",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Sanctions");

            migrationBuilder.RenameColumn(
                name: "SanctionTypeId",
                table: "Sanctions",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sanctions_SanctionTypeId",
                table: "Sanctions",
                newName: "IX_Sanctions_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_Employees_EmployeeId",
                table: "Sanctions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_Employees_EmployeeId",
                table: "Sanctions");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Sanctions",
                newName: "SanctionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sanctions_EmployeeId",
                table: "Sanctions",
                newName: "IX_Sanctions_SanctionTypeId");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Sanctions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Sanctions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sanctions_CreatedById",
                table: "Sanctions",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_Employees_CreatedById",
                table: "Sanctions",
                column: "CreatedById",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_SanctionTypes_SanctionTypeId",
                table: "Sanctions",
                column: "SanctionTypeId",
                principalTable: "SanctionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
