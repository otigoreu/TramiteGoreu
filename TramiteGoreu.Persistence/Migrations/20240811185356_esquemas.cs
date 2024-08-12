using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class esquemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "UserRole",
                newSchema: "General");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User",
                newSchema: "General");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Role",
                newSchema: "General");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserRole",
                schema: "General",
                newName: "UserRole");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "General",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "General",
                newName: "Role");
        }
    }
}
