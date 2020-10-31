using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ayudas",
                columns: table => new
                {
                    AyudaId = table.Column<string>(nullable: false),
                    ValorAyuda = table.Column<int>(nullable: false),
                    Modalidad = table.Column<string>(nullable: true),
                    Fecha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayudas", x => x.AyudaId);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Identificacion = table.Column<string>(nullable: false),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Departamento = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    CodigoAyuda = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Identificacion);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ayudas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
