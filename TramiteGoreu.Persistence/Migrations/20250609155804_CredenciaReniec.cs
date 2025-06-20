using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CredenciaReniec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Pide");

            migrationBuilder.CreateTable(
                name: "CredencialReniec",
                schema: "Pide",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nuDniConsulta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nuDniUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nuRucUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonaID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CredencialReniec", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CredencialReniec_Persona_PersonaID",
                        column: x => x.PersonaID,
                        principalSchema: "General",
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CredencialReniec_PersonaID",
                schema: "Pide",
                table: "CredencialReniec",
                column: "PersonaID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CredencialReniec",
                schema: "Pide");
        }
    }
}
