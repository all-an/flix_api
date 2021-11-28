using Microsoft.EntityFrameworkCore.Migrations;

namespace Flix.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Espectadores",
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
                    table.PrimaryKey("PK_Espectadores", x => x.Id);
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
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    FilmeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EspectadoresFilmes",
                columns: table => new
                {
                    EspectadorId = table.Column<int>(nullable: false),
                    FilmeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspectadoresFilmes", x => new { x.EspectadorId, x.FilmeId });
                    table.ForeignKey(
                        name: "FK_EspectadoresFilmes_Espectadores_EspectadorId",
                        column: x => x.EspectadorId,
                        principalTable: "Espectadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspectadoresFilmes_Filmes_FilmeId",
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
                        name: "FK_EspectadorCategorias_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspectadorCategorias_Espectadores_EspectadorId",
                        column: x => x.EspectadorId,
                        principalTable: "Espectadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Espectadores",
                columns: new[] { "Id", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 1, "Marta", "Kent", "33225555" });

            migrationBuilder.InsertData(
                table: "Espectadores",
                columns: new[] { "Id", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 2, "Paula", "Isabela", "3354288" });

            migrationBuilder.InsertData(
                table: "Espectadores",
                columns: new[] { "Id", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 3, "Laura", "Antonia", "55668899" });

            migrationBuilder.InsertData(
                table: "Espectadores",
                columns: new[] { "Id", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 4, "Luiza", "Maria", "6565659" });

            migrationBuilder.InsertData(
                table: "Espectadores",
                columns: new[] { "Id", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 5, "Lucas", "Machado", "565685415" });

            migrationBuilder.InsertData(
                table: "Espectadores",
                columns: new[] { "Id", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 6, "Pedro", "Alvares", "456454545" });

            migrationBuilder.InsertData(
                table: "Espectadores",
                columns: new[] { "Id", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 7, "Paulo", "José", "9874512" });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Selva" });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Imperador" });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Susto" });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 4, "Vida" });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 5, "Felicidade" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "FilmeId", "Nome" },
                values: new object[] { 1, 1, "Ação" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "FilmeId", "Nome" },
                values: new object[] { 5, 5, "Comédia" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "FilmeId", "Nome" },
                values: new object[] { 2, 2, "Biografia" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "FilmeId", "Nome" },
                values: new object[] { 4, 4, "Drama" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "FilmeId", "Nome" },
                values: new object[] { 3, 3, "Horror" });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 6, 4 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 7, 3 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 6, 3 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 7, 2 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "EspectadoresFilmes",
                columns: new[] { "EspectadorId", "FilmeId" },
                values: new object[] { 7, 5 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 6, 4 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 7, 3 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 6, 3 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 7, 2 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "EspectadorCategorias",
                columns: new[] { "EspectadorId", "CategoriaId" },
                values: new object[] { 7, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_FilmeId",
                table: "Categorias",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_EspectadorCategorias_CategoriaId",
                table: "EspectadorCategorias",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_EspectadoresFilmes_FilmeId",
                table: "EspectadoresFilmes",
                column: "FilmeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EspectadorCategorias");

            migrationBuilder.DropTable(
                name: "EspectadoresFilmes");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Espectadores");

            migrationBuilder.DropTable(
                name: "Filmes");
        }
    }
}
