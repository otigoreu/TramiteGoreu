using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TipoDocumento2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TipoDocumento",
                schema: "Sisgedo",
                newName: "TipoDocumento",
                newSchema: "Administrador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sisgedo");

            migrationBuilder.RenameTable(
                name: "TipoDocumento",
                schema: "Administrador",
                newName: "TipoDocumento",
                newSchema: "Sisgedo");
        }
    }
}
