using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PersonaTelefono2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefono_Persona_PersonaId",
                schema: "General",
                table: "Telefono");

            migrationBuilder.DropIndex(
                name: "IX_Telefono_PersonaId",
                schema: "General",
                table: "Telefono");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                schema: "General",
                table: "Telefono");

            migrationBuilder.CreateIndex(
                name: "IX_Telefono_IdPersona",
                schema: "General",
                table: "Telefono",
                column: "IdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefono_Persona_IdPersona",
                schema: "General",
                table: "Telefono",
                column: "IdPersona",
                principalSchema: "General",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefono_Persona_IdPersona",
                schema: "General",
                table: "Telefono");

            migrationBuilder.DropIndex(
                name: "IX_Telefono_IdPersona",
                schema: "General",
                table: "Telefono");

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                schema: "General",
                table: "Telefono",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Telefono_PersonaId",
                schema: "General",
                table: "Telefono",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefono_Persona_PersonaId",
                schema: "General",
                table: "Telefono",
                column: "PersonaId",
                principalSchema: "General",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
