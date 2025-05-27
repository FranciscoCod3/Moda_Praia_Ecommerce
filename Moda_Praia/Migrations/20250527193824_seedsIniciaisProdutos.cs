using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Moda_Praia.Migrations
{
    /// <inheritdoc />
    public partial class seedsIniciaisProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Categoria", "CorBase", "Descricao", "Nome", "PrecoCusto", "PrecoVenda", "QuantidadeEstoque", "urlName" },
                values: new object[,]
                {
                    { 1, "Biquínis", "Multicolorido", "Biquíni cortininha com estampa floral vibrante, ideal para os dias de sol.", "Biquíni Cortininha Estampado Floral", 35.50m, 79.90m, 50, "biquini-cortininha-floral" },
                    { 2, "Maiôs", "Azul", "Maiô estilo engana mamãe em tecido liso azul, elegante e confortável.", "Maiô Engana Mamãe Liso Azul", 45.00m, 99.90m, 30, "maio-engana-mamae-azul" },
                    { 3, "Saídas de Praia", "Branco", "Saída de praia longa em renda branca, perfeita para um look sofisticado.", "Saída de Praia Longa Renda Branca", 60.00m, 129.90m, 25, "saida-praia-longa-renda-branca" },
                    { 4, "Sungas", "Preto", "Sungão modelo boxer em tecido liso preto, confortável e com bom ajuste.", "Sungão Boxer Liso Preto", 28.00m, 59.90m, 40, "sungao-boxer-preto" },
                    { 5, "Biquínis", "Branco com Poá Preto", "Biquíni tomara que caia com estampa de poá clássica e charmosa.", "Biquíni Tomara que Caia Poá", 40.00m, 89.90m, 35, "biquini-tomara-que-caia-poa" },
                    { 6, "Maiôs", "Multicolorido", "Maiô com corte cavado e estampa tropical vibrante, para um visual moderno.", "Maiô Cavado Estampado Tropical", 50.00m, 109.90m, 20, "maio-cavado-estampado-tropical" },
                    { 7, "Saídas de Praia", "Bege", "Saída de praia curta em crochê, leve e estilosa para os dias quentes.", "Saída de Praia Curta Crochê", 45.00m, 99.90m, 30, "saida-praia-curta-croche" },
                    { 8, "Sungas", "Azul com Listras Brancas", "Sungão modelo slip com estampa listrada, confortável e com ótimo caimento.", "Sungão Slip Listrado", 22.00m, 49.90m, 55, "sungao-slip-listrado" },
                    { 9, "Biquínis", "Vermelho", "Biquíni modelo cropped em tecido liso vermelho, moderno e estiloso.", "Biquíni Cropped Liso Vermelho", 42.00m, 94.90m, 45, "biquini-cropped-vermelho" },
                    { 10, "Maiôs", "Preto com Flores", "Maiô plus size com estampa floral em tons escuros, elegante e confortável.", "Maiô Plus Size Floral Escuro", 55.00m, 119.90m, 15, "maio-plus-size-floral-escuro" },
                    { 11, "Saídas de Praia", "Estampado", "Saída de praia modelo vestido com estampa colorida, prático e charmoso.", "Saída de Praia Vestido Estampado", 52.00m, 114.90m, 28, "saida-praia-vestido-estampado" },
                    { 12, "Sungas", "Multicolorido", "Sungão com estampa abstrata moderna, para um visual diferenciado.", "Sungão Estampado Abstrato", 30.00m, 64.90m, 38, "sungao-estampado-abstrato" },
                    { 13, "Biquínis", "Preto", "Biquíni modelo hot pant em tecido liso preto, elegante e com bom caimento.", "Biquíni Hot Pant Liso Preto", 45.00m, 99.90m, 42, "biquini-hot-pant-preto" },
                    { 14, "Maiôs", "Verde Água", "Maiô com bojo em tecido liso verde água, confortável e com bom suporte.", "Maiô com Bojo Liso Verde Água", 48.00m, 104.90m, 22, "maio-com-bojo-verde-agua" },
                    { 15, "Saídas de Praia", "Branco com Listras Azuis", "Saída de praia modelo camisa com estampa listrada, moderna e versátil.", "Saída de Praia Camisa Listrada", 50.00m, 109.90m, 33, "saida-praia-camisa-listrada" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
