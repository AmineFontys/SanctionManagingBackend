using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SanctionManagingBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSanction4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilledText",
                table: "Sanctions");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Sanctions",
                newName: "SanctionType");

            migrationBuilder.AddColumn<byte[]>(
                name: "PdfFile",
                table: "Sanctions",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfFile",
                table: "Sanctions");

            migrationBuilder.RenameColumn(
                name: "SanctionType",
                table: "Sanctions",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "FilledText",
                table: "Sanctions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
