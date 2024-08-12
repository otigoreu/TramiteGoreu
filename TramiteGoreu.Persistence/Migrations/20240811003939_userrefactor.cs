using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class userrefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "User");

            migrationBuilder.EnsureSchema(
                name: "General");

            migrationBuilder.RenameTable(
                name: "Persona",
                schema: "Administrador",
                newName: "Persona",
                newSchema: "General");

            migrationBuilder.AddColumn<string>(
                name: "celular",
                schema: "General",
                table: "Persona",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "edad",
                schema: "General",
                table: "Persona",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "celular",
                schema: "General",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "edad",
                schema: "General",
                table: "Persona");

            migrationBuilder.EnsureSchema(
                name: "Administrador");

            migrationBuilder.RenameTable(
                name: "Persona",
                schema: "General",
                newName: "Persona",
                newSchema: "Administrador");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<short>(
                name: "DocumentType",
                table: "User",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
