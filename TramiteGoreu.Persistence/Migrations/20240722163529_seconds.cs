using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seconds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.EnsureSchema(
                name: "Administrador");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person",
                newSchema: "Administrador");

            migrationBuilder.AddColumn<string>(
                name: "direccion",
                schema: "Administrador",
                table: "Person",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "email",
                schema: "Administrador",
                table: "Person",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaNac",
                schema: "Administrador",
                table: "Person",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "nroDoc",
                schema: "Administrador",
                table: "Person",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "referencia",
                schema: "Administrador",
                table: "Person",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tipoDoc",
                schema: "Administrador",
                table: "Person",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                schema: "Administrador",
                table: "Person",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                schema: "Administrador",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "direccion",
                schema: "Administrador",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "email",
                schema: "Administrador",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "fechaNac",
                schema: "Administrador",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "nroDoc",
                schema: "Administrador",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "referencia",
                schema: "Administrador",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "tipoDoc",
                schema: "Administrador",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                schema: "Administrador",
                newName: "Persons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");
        }
    }
}
