using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class restructuracion7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Persona_IdPersona",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Sede_IdSede",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioAplicacion_AspNetUsers_IdUsuario",
                table: "UsuarioAplicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRol_AspNetUsers_UserId",
                table: "UsuarioRol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_IdSede",
                table: "Usuario",
                newName: "IX_Usuario_IdSede");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_IdPersona",
                table: "Usuario",
                newName: "IX_Usuario_IdPersona");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Usuario_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Usuario_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_Usuario_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Persona_IdPersona",
                table: "Usuario",
                column: "IdPersona",
                principalSchema: "General",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Sede_IdSede",
                table: "Usuario",
                column: "IdSede",
                principalSchema: "General",
                principalTable: "Sede",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioAplicacion_Usuario_IdUsuario",
                table: "UsuarioAplicacion",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRol_Usuario_UserId",
                table: "UsuarioRol",
                column: "UserId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_Usuario_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_Usuario_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_Usuario_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Persona_IdPersona",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Sede_IdSede",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioAplicacion_Usuario_IdUsuario",
                table: "UsuarioAplicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRol_Usuario_UserId",
                table: "UsuarioRol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "AspNetUsers");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_IdSede",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_IdSede");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_IdPersona",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_IdPersona");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Persona_IdPersona",
                table: "AspNetUsers",
                column: "IdPersona",
                principalSchema: "General",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Sede_IdSede",
                table: "AspNetUsers",
                column: "IdSede",
                principalSchema: "General",
                principalTable: "Sede",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioAplicacion_AspNetUsers_IdUsuario",
                table: "UsuarioAplicacion",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRol_AspNetUsers_UserId",
                table: "UsuarioRol",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
