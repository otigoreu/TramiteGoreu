using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tercer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "Administrador",
                table: "Person",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Administrador",
                table: "Person");
        }
    }
}
