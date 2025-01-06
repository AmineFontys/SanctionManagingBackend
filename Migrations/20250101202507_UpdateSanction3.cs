using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SanctionManagingBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSanction3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Sanctions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Sanctions");
        }
    }
}
