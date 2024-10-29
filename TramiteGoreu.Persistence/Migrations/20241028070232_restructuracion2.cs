using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class restructuracion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UsuarioRol",
                schema: "General",
                newName: "UsuarioRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UsuarioRol",
                newName: "UsuarioRol",
                newSchema: "General");
        }
    }
}
