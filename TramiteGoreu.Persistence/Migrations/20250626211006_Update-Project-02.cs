using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Goreu.Tramite.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProject02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Seguridad");

            migrationBuilder.CreateTable(
                name: "IndiceTabla",
                schema: "Seguridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndiceTabla", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Historial",
                schema: "Seguridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    operacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_pk = table.Column<int>(type: "int", nullable: false),
                    idIndiceTabla = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historial_IndiceTabla_idIndiceTabla",
                        column: x => x.idIndiceTabla,
                        principalSchema: "Seguridad",
                        principalTable: "IndiceTabla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historial_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historial_idIndiceTabla",
                schema: "Seguridad",
                table: "Historial",
                column: "idIndiceTabla");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_idUsuario",
                schema: "Seguridad",
                table: "Historial",
                column: "idUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historial",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "IndiceTabla",
                schema: "Seguridad");
        }
    }
}
