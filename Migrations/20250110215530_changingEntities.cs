using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SanctionManagingBackend.Migrations
{
    /// <inheritdoc />
    public partial class changingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SanctionType",
                table: "Sanctions");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Employees",
                newName: "UserName");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "SanctionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "SanctionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SanctionTemplateId",
                table: "Sanctions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sanctions_SanctionTemplateId",
                table: "Sanctions",
                column: "SanctionTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_SanctionTypes_SanctionTemplateId",
                table: "Sanctions",
                column: "SanctionTemplateId",
                principalTable: "SanctionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_SanctionTypes_SanctionTemplateId",
                table: "Sanctions");

            migrationBuilder.DropIndex(
                name: "IX_Sanctions_SanctionTemplateId",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "SanctionTypes");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "SanctionTypes");

            migrationBuilder.DropColumn(
                name: "SanctionTemplateId",
                table: "Sanctions");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Employees",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "SanctionType",
                table: "Sanctions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
