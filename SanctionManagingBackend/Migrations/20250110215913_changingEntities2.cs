using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SanctionManagingBackend.Migrations
{
    /// <inheritdoc />
    public partial class changingEntities2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_SanctionTypes_SanctionTemplateId",
                table: "Sanctions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SanctionTypes",
                table: "SanctionTypes");

            migrationBuilder.RenameTable(
                name: "SanctionTypes",
                newName: "SanctionTemplate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SanctionTemplate",
                table: "SanctionTemplate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_SanctionTemplate_SanctionTemplateId",
                table: "Sanctions",
                column: "SanctionTemplateId",
                principalTable: "SanctionTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_SanctionTemplate_SanctionTemplateId",
                table: "Sanctions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SanctionTemplate",
                table: "SanctionTemplate");

            migrationBuilder.RenameTable(
                name: "SanctionTemplate",
                newName: "SanctionTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SanctionTypes",
                table: "SanctionTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_SanctionTypes_SanctionTemplateId",
                table: "Sanctions",
                column: "SanctionTemplateId",
                principalTable: "SanctionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
