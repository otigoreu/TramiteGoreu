using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RoleNAme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuRol_Role_IdRol",
                table: "MenuRol");

            migrationBuilder.RenameColumn(
                name: "IdRol",
                table: "MenuRol",
                newName: "IdRole");

            migrationBuilder.RenameIndex(
                name: "IX_MenuRol_IdRol",
                table: "MenuRol",
                newName: "IX_MenuRol_IdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuRol_Role_IdRole",
                table: "MenuRol",
                column: "IdRole",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuRol_Role_IdRole",
                table: "MenuRol");

            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "MenuRol",
                newName: "IdRol");

            migrationBuilder.RenameIndex(
                name: "IX_MenuRol_IdRole",
                table: "MenuRol",
                newName: "IX_MenuRol_IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuRol_Role_IdRol",
                table: "MenuRol",
                column: "IdRol",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
