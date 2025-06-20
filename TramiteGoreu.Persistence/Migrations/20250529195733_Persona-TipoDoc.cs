using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PersonaTipoDoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDoc",
                schema: "General",
                table: "Persona");

            migrationBuilder.AddColumn<int>(
                name: "IdTipoDoc",
                schema: "General",
                table: "Persona",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdTipoDoc",
                schema: "General",
                table: "Persona",
                column: "IdTipoDoc");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_TipoDocumento_IdTipoDoc",
                schema: "General",
                table: "Persona",
                column: "IdTipoDoc",
                principalSchema: "Administrador",
                principalTable: "TipoDocumento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_TipoDocumento_IdTipoDoc",
                schema: "General",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Persona_IdTipoDoc",
                schema: "General",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "IdTipoDoc",
                schema: "General",
                table: "Persona");

            migrationBuilder.AddColumn<string>(
                name: "TipoDoc",
                schema: "General",
                table: "Persona",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }
    }
}
