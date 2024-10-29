using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class restructuracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_Role_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_User_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_User_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_User_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId",
                schema: "General",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                schema: "General",
                table: "UserRole");

            migrationBuilder.DropTable(
                name: "User",
                schema: "General");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                schema: "General",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                schema: "General",
                table: "Role");

            migrationBuilder.EnsureSchema(
                name: "Administrador");

            migrationBuilder.RenameTable(
                name: "UserRole",
                schema: "General",
                newName: "UsuarioRol",
                newSchema: "General");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "General",
                newName: "AspNetRoles");

            migrationBuilder.RenameColumn(
                name: "tipoDoc",
                schema: "General",
                table: "Persona",
                newName: "TipoDoc");

            migrationBuilder.RenameColumn(
                name: "referencia",
                schema: "General",
                table: "Persona",
                newName: "Referencia");

            migrationBuilder.RenameColumn(
                name: "nroDoc",
                schema: "General",
                table: "Persona",
                newName: "NroDoc");

            migrationBuilder.RenameColumn(
                name: "nombres",
                schema: "General",
                table: "Persona",
                newName: "Nombres");

            migrationBuilder.RenameColumn(
                name: "fechaNac",
                schema: "General",
                table: "Persona",
                newName: "FechaNac");

            migrationBuilder.RenameColumn(
                name: "email",
                schema: "General",
                table: "Persona",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "edad",
                schema: "General",
                table: "Persona",
                newName: "Edad");

            migrationBuilder.RenameColumn(
                name: "direccion",
                schema: "General",
                table: "Persona",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "celular",
                schema: "General",
                table: "Persona",
                newName: "Celular");

            migrationBuilder.RenameColumn(
                name: "apellidos",
                schema: "General",
                table: "Persona",
                newName: "Apellidos");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_RoleId",
                schema: "General",
                table: "UsuarioRol",
                newName: "IX_UsuarioRol_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioRol",
                schema: "General",
                table: "UsuarioRol",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Aplicacion",
                schema: "Administrador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "Administrador",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CanCreate = table.Column<bool>(type: "bit", nullable: false),
                    CanDelete = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdate = table.Column<bool>(type: "bit", nullable: false),
                    CanSearch = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Sede",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sede", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "Administrador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IconName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Route = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdAplicacion = table.Column<int>(type: "int", nullable: false),
                    ParentMenuId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Aplicacion_IdAplicacion",
                        column: x => x.IdAplicacion,
                        principalSchema: "Administrador",
                        principalTable: "Aplicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_ParentMenuId",
                        column: x => x.ParentMenuId,
                        principalSchema: "Administrador",
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SedeAplicacion",
                columns: table => new
                {
                    IdSede = table.Column<int>(type: "int", nullable: false),
                    IdAplicacion = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SedeAplicacion", x => new { x.IdSede, x.IdAplicacion });
                    table.ForeignKey(
                        name: "FK_SedeAplicacion_Aplicacion_IdAplicacion",
                        column: x => x.IdAplicacion,
                        principalSchema: "Administrador",
                        principalTable: "Aplicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SedeAplicacion_Sede_IdSede",
                        column: x => x.IdSede,
                        principalSchema: "General",
                        principalTable: "Sede",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdSede = table.Column<int>(type: "int", nullable: false),
                    IdPersona = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Persona_IdPersona",
                        column: x => x.IdPersona,
                        principalSchema: "General",
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Sede_IdSede",
                        column: x => x.IdSede,
                        principalSchema: "General",
                        principalTable: "Sede",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuRol",
                columns: table => new
                {
                    IdMenu = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRol", x => new { x.IdMenu, x.IdRol });
                    table.ForeignKey(
                        name: "FK_MenuRol_Menu_IdMenu",
                        column: x => x.IdMenu,
                        principalSchema: "Administrador",
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuRol_Rol_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "Administrador",
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioAplicacion",
                columns: table => new
                {
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdAplicacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioAplicacion", x => new { x.IdUsuario, x.IdAplicacion });
                    table.ForeignKey(
                        name: "FK_UsuarioAplicacion_Aplicacion_IdAplicacion",
                        column: x => x.IdAplicacion,
                        principalSchema: "Administrador",
                        principalTable: "Aplicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioAplicacion_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "General",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_IdAplicacion",
                schema: "Administrador",
                table: "Menu",
                column: "IdAplicacion");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ParentMenuId",
                schema: "Administrador",
                table: "Menu",
                column: "ParentMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRol_IdRol",
                table: "MenuRol",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_SedeAplicacion_IdAplicacion",
                table: "SedeAplicacion",
                column: "IdAplicacion");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "General",
                table: "Usuario",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdPersona",
                schema: "General",
                table: "Usuario",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdSede",
                schema: "General",
                table: "Usuario",
                column: "IdSede");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "General",
                table: "Usuario",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioAplicacion_IdAplicacion",
                table: "UsuarioAplicacion",
                column: "IdAplicacion");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

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
                name: "FK_UsuarioRol_AspNetRoles_RoleId",
                schema: "General",
                table: "UsuarioRol");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRol_Usuario_UserId",
                schema: "General",
                table: "UsuarioRol");

            migrationBuilder.DropTable(
                name: "MenuRol");

            migrationBuilder.DropTable(
                name: "SedeAplicacion");

            migrationBuilder.DropTable(
                name: "UsuarioAplicacion");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "Administrador");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "Administrador");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "General");

            migrationBuilder.DropTable(
                name: "Aplicacion",
                schema: "Administrador");

            migrationBuilder.DropTable(
                name: "Sede",
                schema: "General");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioRol",
                schema: "General",
                table: "UsuarioRol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "UsuarioRol",
                schema: "General",
                newName: "UserRole",
                newSchema: "General");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Role",
                newSchema: "General");

            migrationBuilder.RenameColumn(
                name: "TipoDoc",
                schema: "General",
                table: "Persona",
                newName: "tipoDoc");

            migrationBuilder.RenameColumn(
                name: "Referencia",
                schema: "General",
                table: "Persona",
                newName: "referencia");

            migrationBuilder.RenameColumn(
                name: "NroDoc",
                schema: "General",
                table: "Persona",
                newName: "nroDoc");

            migrationBuilder.RenameColumn(
                name: "Nombres",
                schema: "General",
                table: "Persona",
                newName: "nombres");

            migrationBuilder.RenameColumn(
                name: "FechaNac",
                schema: "General",
                table: "Persona",
                newName: "fechaNac");

            migrationBuilder.RenameColumn(
                name: "Email",
                schema: "General",
                table: "Persona",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Edad",
                schema: "General",
                table: "Persona",
                newName: "edad");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                schema: "General",
                table: "Persona",
                newName: "direccion");

            migrationBuilder.RenameColumn(
                name: "Celular",
                schema: "General",
                table: "Persona",
                newName: "celular");

            migrationBuilder.RenameColumn(
                name: "Apellidos",
                schema: "General",
                table: "Persona",
                newName: "apellidos");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioRol_RoleId",
                schema: "General",
                table: "UserRole",
                newName: "IX_UserRole_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                schema: "General",
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                schema: "General",
                table: "Role",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "General",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "General",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_Role_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalSchema: "General",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_User_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "General",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_User_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "General",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_User_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "General",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RoleId",
                schema: "General",
                table: "UserRole",
                column: "RoleId",
                principalSchema: "General",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId",
                schema: "General",
                table: "UserRole",
                column: "UserId",
                principalSchema: "General",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
