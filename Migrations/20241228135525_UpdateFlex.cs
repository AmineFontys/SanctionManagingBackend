using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SanctionManagingBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFlex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMale",
                table: "Flexworkers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMale",
                table: "Flexworkers");
        }
    }
}
