using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SanctionManagingBackend.Migrations
{
    /// <inheritdoc />
    public partial class SanctionTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_Employees_EmployeeId",
                table: "Sanctions");

            migrationBuilder.DropIndex(
                name: "IX_Sanctions_EmployeeId",
                table: "Sanctions");

            migrationBuilder.RenameColumn(
                name: "StandardLetterTemplate",
                table: "SanctionTypes",
                newName: "TemplateText");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Sanctions",
                newName: "CreatedByUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SanctionTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SanctionTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SanctionTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "SanctionTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Sanctions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Sanctions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FilledText",
                table: "Sanctions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_Employees_CreatedById",
                table: "Sanctions");

            migrationBuilder.DropIndex(
                name: "IX_Sanctions_CreatedById",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SanctionTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "SanctionTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "FilledText",
                table: "Sanctions");

            migrationBuilder.RenameColumn(
                name: "TemplateText",
                table: "SanctionTypes",
                newName: "StandardLetterTemplate");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Sanctions",
                newName: "EmployeeId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SanctionTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SanctionTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Sanctions_EmployeeId",
                table: "Sanctions",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_Employees_EmployeeId",
                table: "Sanctions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
