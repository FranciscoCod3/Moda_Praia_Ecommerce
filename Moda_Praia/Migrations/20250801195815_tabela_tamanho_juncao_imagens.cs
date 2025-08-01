using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moda_Praia.Migrations
{
    /// <inheritdoc />
    public partial class tabela_tamanho_juncao_imagens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoImagem_Produtos_ProdutoId",
                table: "ProdutoImagem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoImagem",
                table: "ProdutoImagem");

            migrationBuilder.RenameTable(
                name: "ProdutoImagem",
                newName: "ProdutoImagens");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoImagem_ProdutoId",
                table: "ProdutoImagens",
                newName: "IX_ProdutoImagens_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoImagens",
                table: "ProdutoImagens",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tamanhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tamanhos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoTamanhos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    TamanhoId = table.Column<int>(type: "int", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoTamanhos", x => new { x.ProdutoId, x.TamanhoId });
                    table.ForeignKey(
                        name: "FK_ProdutoTamanhos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoTamanhos_Tamanhos_TamanhoId",
                        column: x => x.TamanhoId,
                        principalTable: "Tamanhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoTamanhos_TamanhoId",
                table: "ProdutoTamanhos",
                column: "TamanhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoImagens_Produtos_ProdutoId",
                table: "ProdutoImagens",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoImagens_Produtos_ProdutoId",
                table: "ProdutoImagens");

            migrationBuilder.DropTable(
                name: "ProdutoTamanhos");

            migrationBuilder.DropTable(
                name: "Tamanhos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoImagens",
                table: "ProdutoImagens");

            migrationBuilder.RenameTable(
                name: "ProdutoImagens",
                newName: "ProdutoImagem");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoImagens_ProdutoId",
                table: "ProdutoImagem",
                newName: "IX_ProdutoImagem_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoImagem",
                table: "ProdutoImagem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoImagem_Produtos_ProdutoId",
                table: "ProdutoImagem",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
