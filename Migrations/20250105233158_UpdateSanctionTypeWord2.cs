using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SanctionManagingBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSanctionTypeWord2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PdfBase64",
                table: "SanctionTypes",
                newName: "WordBase64");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WordBase64",
                table: "SanctionTypes",
                newName: "PdfBase64");
        }
    }
}
