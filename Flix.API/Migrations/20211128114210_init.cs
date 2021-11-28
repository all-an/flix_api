using Microsoft.EntityFrameworkCore.Migrations;

namespace Flix.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Espectador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espectador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoriasw",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    FilmeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoriasw", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoriasw_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EspectadorCategorias",
                columns: table => new
                {
                    EspectadorId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspectadorCategorias", x => new { x.EspectadorId, x.CategoriaId });
                    table.ForeignKey(
                        name: "FK_EspectadorCategorias_Categoriasw_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoriasw",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspectadorCategorias_Espectador_EspectadorId",
                        column: x => x.EspectadorId,
                        principalTable: "Espectador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoriasw_FilmeId",
                table: "Categoriasw",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_EspectadorCategorias_CategoriaId",
                table: "EspectadorCategorias",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EspectadorCategorias");

            migrationBuilder.DropTable(
                name: "Categoriasw");

            migrationBuilder.DropTable(
                name: "Espectador");

            migrationBuilder.DropTable(
                name: "Filmes");
        }
    }
}
