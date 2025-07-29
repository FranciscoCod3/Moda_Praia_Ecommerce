using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Moda_Praia.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoVenda = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PrecoCusto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantidadeEstoque = table.Column<int>(type: "int", nullable: true),
                    CorBase = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoImagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlImagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoImagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoImagem_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CorBase", "Descricao", "Nome", "PrecoCusto", "PrecoVenda", "QuantidadeEstoque" },
                values: new object[,]
                {
                    { 1, "Multicolorido", "Biquíni cortininha com estampa floral vibrante, ideal para os dias de sol.", "Biquíni Cortininha Estampado Floral", 35.50m, 79.90m, 50 },
                    { 2, "Azul", "Maiô estilo engana mamãe em tecido liso azul, elegante e confortável.", "Maiô Engana Mamãe Liso Azul", 45.00m, 99.90m, 30 },
                    { 3, "Branco", "Saída de praia longa em renda branca, perfeita para um look sofisticado.", "Saída de Praia Longa Renda Branca", 60.00m, 129.90m, 25 },
                    { 4, "Preto", "Sungão modelo boxer em tecido liso preto, confortável e com bom ajuste.", "Sungão Boxer Liso Preto", 28.00m, 59.90m, 40 },
                    { 5, "Branco com Poá Preto", "Biquíni tomara que caia com estampa de poá clássica e charmosa.", "Biquíni Tomara que Caia Poá", 40.00m, 89.90m, 35 },
                    { 6, "Multicolorido", "Maiô com corte cavado e estampa tropical vibrante, para um visual moderno.", "Maiô Cavado Estampado Tropical", 50.00m, 109.90m, 20 },
                    { 7, "Bege", "Saída de praia curta em crochê, leve e estilosa para os dias quentes.", "Saída de Praia Curta Crochê", 45.00m, 99.90m, 30 },
                    { 8, "Azul com Listras Brancas", "Sungão modelo slip com estampa listrada, confortável e com ótimo caimento.", "Sungão Slip Listrado", 22.00m, 49.90m, 55 },
                    { 9, "Vermelho", "Biquíni modelo cropped em tecido liso vermelho, moderno e estiloso.", "Biquíni Cropped Liso Vermelho", 42.00m, 94.90m, 45 },
                    { 10, "Preto com Flores", "Maiô plus size com estampa floral em tons escuros, elegante e confortável.", "Maiô Plus Size Floral Escuro", 55.00m, 119.90m, 15 },
                    { 11, "Estampado", "Saída de praia modelo vestido com estampa colorida, prático e charmoso.", "Saída de Praia Vestido Estampado", 52.00m, 114.90m, 28 },
                    { 12, "Multicolorido", "Sungão com estampa abstrata moderna, para um visual diferenciado.", "Sungão Estampado Abstrato", 30.00m, 64.90m, 38 },
                    { 13, "Preto", "Biquíni modelo hot pant em tecido liso preto, elegante e com bom caimento.", "Biquíni Hot Pant Liso Preto", 45.00m, 99.90m, 42 },
                    { 14, "Verde Água", "Maiô com bojo em tecido liso verde água, confortável e com bom suporte.", "Maiô com Bojo Liso Verde Água", 48.00m, 104.90m, 22 },
                    { 15, "Branco com Listras Azuis", "Saída de praia modelo camisa com estampa listrada, moderna e versátil.", "Saída de Praia Camisa Listrada", 50.00m, 109.90m, 33 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoImagem_ProdutoId",
                table: "ProdutoImagem",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoImagem");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
