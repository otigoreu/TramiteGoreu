using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PersonaTelefono4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdTelefono",
                schema: "General",
                table: "Telefono",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "General",
                table: "Telefono",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "General",
                table: "Telefono");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "General",
                table: "Telefono",
                newName: "IdTelefono");
        }
    }
}
