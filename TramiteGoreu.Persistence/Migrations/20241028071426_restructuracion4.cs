using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class restructuracion4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Usuario_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "Rol",
                schema: "Administrador",
                newName: "Rol",
                newSchema: "General");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "UsuarioRol",
                newSchema: "General");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "General",
                table: "UsuarioRol",
                newName: "IX_UsuarioRol_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioRol",
                schema: "General",
                table: "UsuarioRol",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRol_AspNetRoles_RoleId",
                schema: "General",
                table: "UsuarioRol",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRol_Usuario_UserId",
                schema: "General",
                table: "UsuarioRol",
                column: "UserId",
                principalSchema: "General",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRol_AspNetRoles_RoleId",
                schema: "General",
                table: "UsuarioRol");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRol_Usuario_UserId",
                schema: "General",
                table: "UsuarioRol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioRol",
                schema: "General",
                table: "UsuarioRol");

            migrationBuilder.RenameTable(
                name: "Rol",
                schema: "General",
                newName: "Rol",
                newSchema: "Administrador");

            migrationBuilder.RenameTable(
                name: "UsuarioRol",
                schema: "General",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioRol_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Usuario_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "General",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
