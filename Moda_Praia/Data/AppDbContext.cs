using Microsoft.EntityFrameworkCore;
using Moda_Praia.Models;

namespace Moda_Praia.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasData(
                new Produto
                {
                    Id = 1,
                    Nome = "Biquíni Cortininha Estampado Floral",
                    PrecoVenda = 79.90m,
                    PrecoCusto = 35.50m,
                    Descricao = "Biquíni cortininha com estampa floral vibrante, ideal para os dias de sol.",
                    Categoria = "Biquínis",
                    urlName = "biquini-cortininha-floral",
                    QuantidadeEstoque = 50,
                    CorBase = "Multicolorido"
                },
                new Produto
                {
                    Id = 2,
                    Nome = "Maiô Engana Mamãe Liso Azul",
                    PrecoVenda = 99.90m,
                    PrecoCusto = 45.00m,
                    Descricao = "Maiô estilo engana mamãe em tecido liso azul, elegante e confortável.",
                    Categoria = "Maiôs",
                    urlName = "maio-engana-mamae-azul",
                    QuantidadeEstoque = 30,
                    CorBase = "Azul"
                },
                new Produto
                {
                    Id = 3,
                    Nome = "Saída de Praia Longa Renda Branca",
                    PrecoVenda = 129.90m,
                    PrecoCusto = 60.00m,
                    Descricao = "Saída de praia longa em renda branca, perfeita para um look sofisticado.",
                    Categoria = "Saídas de Praia",
                    urlName = "saida-praia-longa-renda-branca",
                    QuantidadeEstoque = 25,
                    CorBase = "Branco"
                },
                new Produto
                {
                    Id = 4,
                    Nome = "Sungão Boxer Liso Preto",
                    PrecoVenda = 59.90m,
                    PrecoCusto = 28.00m,
                    Descricao = "Sungão modelo boxer em tecido liso preto, confortável e com bom ajuste.",
                    Categoria = "Sungas",
                    urlName = "sungao-boxer-preto",
                    QuantidadeEstoque = 40,
                    CorBase = "Preto"
                },
                new Produto
                {
                    Id = 5,
                    Nome = "Biquíni Tomara que Caia Poá",
                    PrecoVenda = 89.90m,
                    PrecoCusto = 40.00m,
                    Descricao = "Biquíni tomara que caia com estampa de poá clássica e charmosa.",
                    Categoria = "Biquínis",
                    urlName = "biquini-tomara-que-caia-poa",
                    QuantidadeEstoque = 35,
                    CorBase = "Branco com Poá Preto"
                },
                new Produto
                {
                    Id = 6,
                    Nome = "Maiô Cavado Estampado Tropical",
                    PrecoVenda = 109.90m,
                    PrecoCusto = 50.00m,
                    Descricao = "Maiô com corte cavado e estampa tropical vibrante, para um visual moderno.",
                    Categoria = "Maiôs",
                    urlName = "maio-cavado-estampado-tropical",
                    QuantidadeEstoque = 20,
                    CorBase = "Multicolorido"
                },
                new Produto
                {
                    Id = 7,
                    Nome = "Saída de Praia Curta Crochê",
                    PrecoVenda = 99.90m,
                    PrecoCusto = 45.00m,
                    Descricao = "Saída de praia curta em crochê, leve e estilosa para os dias quentes.",
                    Categoria = "Saídas de Praia",
                    urlName = "saida-praia-curta-croche",
                    QuantidadeEstoque = 30,
                    CorBase = "Bege"
                },
                new Produto
                {
                    Id = 8,
                    Nome = "Sungão Slip Listrado",
                    PrecoVenda = 49.90m,
                    PrecoCusto = 22.00m,
                    Descricao = "Sungão modelo slip com estampa listrada, confortável e com ótimo caimento.",
                    Categoria = "Sungas",
                    urlName = "sungao-slip-listrado",
                    QuantidadeEstoque = 55,
                    CorBase = "Azul com Listras Brancas"
                },
                new Produto
                {
                    Id = 9,
                    Nome = "Biquíni Cropped Liso Vermelho",
                    PrecoVenda = 94.90m,
                    PrecoCusto = 42.00m,
                    Descricao = "Biquíni modelo cropped em tecido liso vermelho, moderno e estiloso.",
                    Categoria = "Biquínis",
                    urlName = "biquini-cropped-vermelho",
                    QuantidadeEstoque = 45,
                    CorBase = "Vermelho"
                },
                new Produto
                {
                    Id = 10,
                    Nome = "Maiô Plus Size Floral Escuro",
                    PrecoVenda = 119.90m,
                    PrecoCusto = 55.00m,
                    Descricao = "Maiô plus size com estampa floral em tons escuros, elegante e confortável.",
                    Categoria = "Maiôs",
                    urlName = "maio-plus-size-floral-escuro",
                    QuantidadeEstoque = 15,
                    CorBase = "Preto com Flores"
                },
                new Produto
                {
                    Id = 11,
                    Nome = "Saída de Praia Vestido Estampado",
                    PrecoVenda = 114.90m,
                    PrecoCusto = 52.00m,
                    Descricao = "Saída de praia modelo vestido com estampa colorida, prático e charmoso.",
                    Categoria = "Saídas de Praia",
                    urlName = "saida-praia-vestido-estampado",
                    QuantidadeEstoque = 28,
                    CorBase = "Estampado"
                },
                new Produto
                {
                    Id = 12,
                    Nome = "Sungão Estampado Abstrato",
                    PrecoVenda = 64.90m,
                    PrecoCusto = 30.00m,
                    Descricao = "Sungão com estampa abstrata moderna, para um visual diferenciado.",
                    Categoria = "Sungas",
                    urlName = "sungao-estampado-abstrato",
                    QuantidadeEstoque = 38,
                    CorBase = "Multicolorido"
                },
                new Produto
                {
                    Id = 13,
                    Nome = "Biquíni Hot Pant Liso Preto",
                    PrecoVenda = 99.90m,
                    PrecoCusto = 45.00m,
                    Descricao = "Biquíni modelo hot pant em tecido liso preto, elegante e com bom caimento.",
                    Categoria = "Biquínis",
                    urlName = "biquini-hot-pant-preto",
                    QuantidadeEstoque = 42,
                    CorBase = "Preto"
                },
                new Produto
                {
                    Id = 14,
                    Nome = "Maiô com Bojo Liso Verde Água",
                    PrecoVenda = 104.90m,
                    PrecoCusto = 48.00m,
                    Descricao = "Maiô com bojo em tecido liso verde água, confortável e com bom suporte.",
                    Categoria = "Maiôs",
                    urlName = "maio-com-bojo-verde-agua",
                    QuantidadeEstoque = 22,
                    CorBase = "Verde Água"
                },
                new Produto
                {
                    Id = 15,
                    Nome = "Saída de Praia Camisa Listrada",
                    PrecoVenda = 109.90m,
                    PrecoCusto = 50.00m,
                    Descricao = "Saída de praia modelo camisa com estampa listrada, moderna e versátil.",
                    Categoria = "Saídas de Praia",
                    urlName = "saida-praia-camisa-listrada",
                    QuantidadeEstoque = 33,
                    CorBase = "Branco com Listras Azuis"
                }
            );
        }
    }
}