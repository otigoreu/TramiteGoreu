using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramiteGoreu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class esES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person",
                schema: "Administrador");

            migrationBuilder.CreateTable(
                name: "Persona",
                schema: "Administrador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fechaNac = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "GETDATE()"),
                    direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tipoDoc = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    nroDoc = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persona",
                schema: "Administrador");

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Administrador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fechaNac = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "GETDATE()"),
                    nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nroDoc = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    tipoDoc = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });
        }
    }
}
