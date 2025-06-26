using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Goreu.Tramite.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProject01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntidadAplicacion_Aplicacion_AplicacionId",
                table: "EntidadAplicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_EntidadAplicacion_Entidad_EntidadId",
                table: "EntidadAplicacion");

            migrationBuilder.DropIndex(
                name: "IX_EntidadAplicacion_AplicacionId",
                table: "EntidadAplicacion");

            migrationBuilder.DropIndex(
                name: "IX_EntidadAplicacion_EntidadId",
                table: "EntidadAplicacion");

            migrationBuilder.DropColumn(
                name: "AplicacionId",
                table: "EntidadAplicacion");

            migrationBuilder.DropColumn(
                name: "EntidadId",
                table: "EntidadAplicacion");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadAplicacion_IdAplicacion",
                table: "EntidadAplicacion",
                column: "IdAplicacion");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadAplicacion_IdEntidad",
                table: "EntidadAplicacion",
                column: "IdEntidad");

            migrationBuilder.AddForeignKey(
                name: "FK_EntidadAplicacion_Aplicacion_IdAplicacion",
                table: "EntidadAplicacion",
                column: "IdAplicacion",
                principalSchema: "Administrador",
                principalTable: "Aplicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntidadAplicacion_Entidad_IdEntidad",
                table: "EntidadAplicacion",
                column: "IdEntidad",
                principalSchema: "Administrador",
                principalTable: "Entidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntidadAplicacion_Aplicacion_IdAplicacion",
                table: "EntidadAplicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_EntidadAplicacion_Entidad_IdEntidad",
                table: "EntidadAplicacion");

            migrationBuilder.DropIndex(
                name: "IX_EntidadAplicacion_IdAplicacion",
                table: "EntidadAplicacion");

            migrationBuilder.DropIndex(
                name: "IX_EntidadAplicacion_IdEntidad",
                table: "EntidadAplicacion");

            migrationBuilder.AddColumn<int>(
                name: "AplicacionId",
                table: "EntidadAplicacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EntidadId",
                table: "EntidadAplicacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EntidadAplicacion_AplicacionId",
                table: "EntidadAplicacion",
                column: "AplicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadAplicacion_EntidadId",
                table: "EntidadAplicacion",
                column: "EntidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntidadAplicacion_Aplicacion_AplicacionId",
                table: "EntidadAplicacion",
                column: "AplicacionId",
                principalSchema: "Administrador",
                principalTable: "Aplicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntidadAplicacion_Entidad_EntidadId",
                table: "EntidadAplicacion",
                column: "EntidadId",
                principalSchema: "Administrador",
                principalTable: "Entidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
