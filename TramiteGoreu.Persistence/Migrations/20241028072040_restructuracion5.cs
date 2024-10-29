using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class restructuracion5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_MenuRol_Rol_IdRol",
                table: "MenuRol");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Persona_IdPersona",
                schema: "General",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Sede_IdSede",
                schema: "General",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioAplicacion_Usuario_IdUsuario",
                table: "UsuarioAplicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRol_AspNetRoles_RoleId",
                schema: "General",
                table: "UsuarioRol");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRol_Usuario_UserId",
                schema: "General",
                table: "UsuarioRol");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "General");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioRol",
                schema: "General",
                table: "UsuarioRol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                schema: "General",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "UsuarioRol",
                schema: "General",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "Usuario",
                schema: "General",
                newName: "AspNetUsers");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioRol_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_IdSede",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_IdSede");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_IdPersona",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_IdPersona");

            migrationBuilder.AddColumn<bool>(
                name: "CanCreate",
                table: "AspNetRoles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CanDelete",
                table: "AspNetRoles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CanSearch",
                table: "AspNetRoles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CanUpdate",
                table: "AspNetRoles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

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
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
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
                name: "FK_MenuRol_AspNetRoles_IdRol",
                table: "MenuRol",
                column: "IdRol",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioAplicacion_AspNetUsers_IdUsuario",
                table: "UsuarioAplicacion",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

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
                name: "FK_MenuRol_AspNetRoles_IdRol",
                table: "MenuRol");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioAplicacion_AspNetUsers_IdUsuario",
                table: "UsuarioAplicacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "CanCreate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "CanDelete",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "CanSearch",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "CanUpdate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Usuario",
                newSchema: "General");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "UsuarioRol",
                newSchema: "General");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_IdSede",
                schema: "General",
                table: "Usuario",
                newName: "IX_Usuario_IdSede");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_IdPersona",
                schema: "General",
                table: "Usuario",
                newName: "IX_Usuario_IdPersona");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "General",
                table: "UsuarioRol",
                newName: "IX_UsuarioRol_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                schema: "General",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioRol",
                schema: "General",
                table: "UsuarioRol",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CanCreate = table.Column<bool>(type: "bit", nullable: false),
                    CanDelete = table.Column<bool>(type: "bit", nullable: false),
                    CanSearch = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rol_AspNetRoles_Id",
                        column: x => x.Id,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Usuario_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "General",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Usuario_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "General",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_Usuario_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "General",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuRol_Rol_IdRol",
                table: "MenuRol",
                column: "IdRol",
                principalSchema: "General",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Persona_IdPersona",
                schema: "General",
                table: "Usuario",
                column: "IdPersona",
                principalSchema: "General",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Sede_IdSede",
                schema: "General",
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
                principalSchema: "General",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
