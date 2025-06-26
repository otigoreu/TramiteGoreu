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
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioUnidadOrganica_UnidadOrganica_UnidadOrganicaId",
                table: "UsuarioUnidadOrganica");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioUnidadOrganica_Usuario_UsuarioId",
                table: "UsuarioUnidadOrganica");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioUnidadOrganica_UnidadOrganicaId",
                table: "UsuarioUnidadOrganica");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioUnidadOrganica_UsuarioId",
                table: "UsuarioUnidadOrganica");

            migrationBuilder.DropColumn(
                name: "UnidadOrganicaId",
                table: "UsuarioUnidadOrganica");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "UsuarioUnidadOrganica");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsuario",
                table: "UsuarioUnidadOrganica",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioUnidadOrganica_IdUnidadOrganica",
                table: "UsuarioUnidadOrganica",
                column: "IdUnidadOrganica");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioUnidadOrganica_IdUsuario",
                table: "UsuarioUnidadOrganica",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioUnidadOrganica_UnidadOrganica_IdUnidadOrganica",
                table: "UsuarioUnidadOrganica",
                column: "IdUnidadOrganica",
                principalSchema: "General",
                principalTable: "UnidadOrganica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioUnidadOrganica_Usuario_IdUsuario",
                table: "UsuarioUnidadOrganica",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioUnidadOrganica_UnidadOrganica_IdUnidadOrganica",
                table: "UsuarioUnidadOrganica");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioUnidadOrganica_Usuario_IdUsuario",
                table: "UsuarioUnidadOrganica");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioUnidadOrganica_IdUnidadOrganica",
                table: "UsuarioUnidadOrganica");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioUnidadOrganica_IdUsuario",
                table: "UsuarioUnidadOrganica");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsuario",
                table: "UsuarioUnidadOrganica",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AddColumn<int>(
                name: "UnidadOrganicaId",
                table: "UsuarioUnidadOrganica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "UsuarioUnidadOrganica",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioUnidadOrganica_UnidadOrganicaId",
                table: "UsuarioUnidadOrganica",
                column: "UnidadOrganicaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioUnidadOrganica_UsuarioId",
                table: "UsuarioUnidadOrganica",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioUnidadOrganica_UnidadOrganica_UnidadOrganicaId",
                table: "UsuarioUnidadOrganica",
                column: "UnidadOrganicaId",
                principalSchema: "General",
                principalTable: "UnidadOrganica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioUnidadOrganica_Usuario_UsuarioId",
                table: "UsuarioUnidadOrganica",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
