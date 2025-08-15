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
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tamanho> Tamanhos { get; set; }
        public DbSet<ProdutoTamanho> ProdutoTamanhos { get; set; }
        public DbSet<ProdutoImagem> ProdutoImagens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProdutoTamanho>()
            .HasKey(pt => new { pt.ProdutoId, pt.TamanhoId });

            // Configura as relações de muitos para muitos (opcional, o EF Core pode inferir)
            modelBuilder.Entity<ProdutoTamanho>()
                .HasOne(pt => pt.Produto)
                .WithMany(p => p.ProdutoTamanhos)
                .HasForeignKey(pt => pt.ProdutoId);

            modelBuilder.Entity<ProdutoTamanho>()
                .HasOne(pt => pt.Tamanho)
                .WithMany(t => t.ProdutoTamanhos)
                .HasForeignKey(pt => pt.TamanhoId);

            modelBuilder.Entity<Produto>().HasData(
                new Produto
                {
                   Id = 1,
                   Nome = "Biquíni Cortininha Estampado Floral",
                   PrecoVenda = 79.90m,
                   PrecoCusto = 35.50m,
                   Descricao = "Biquíni cortininha com estampa floral vibrante, ideal para os dias de sol.",
                   CorBase = "Multicolorido",
                   CategoriaId = 1
                },
                new Produto
                {
                    Id = 2,
                    Nome = "Maiô Engana Mamãe Liso Azul",
                    PrecoVenda = 99.90m,
                    PrecoCusto = 45.00m,
                    Descricao = "Maiô estilo engana mamãe em tecido liso azul, elegante e confortável.",                    
                    CorBase = "Azul",
                    CategoriaId = 2
                },
                new Produto
                {
                    Id = 3,
                    Nome = "Saída de Praia Longa Renda Branca",
                    PrecoVenda = 129.90m,
                    PrecoCusto = 60.00m,
                    Descricao = "Saída de praia longa em renda branca, perfeita para um look sofisticado.",                    
                    CorBase = "Branco",
                    CategoriaId = 3
                },
                new Produto
                {
                    Id = 4,
                    Nome = "Sungão Boxer Liso Preto",
                    PrecoVenda = 59.90m,
                    PrecoCusto = 28.00m,
                    Descricao = "Sungão modelo boxer em tecido liso preto, confortável e com bom ajuste.",                    
                    CorBase = "Preto",
                    CategoriaId = 1
                },
                new Produto
                {
                    Id = 5,
                    Nome = "Biquíni Tomara que Caia Poá",
                    PrecoVenda = 89.90m,
                    PrecoCusto = 40.00m,
                    Descricao = "Biquíni tomara que caia com estampa de poá clássica e charmosa.",                   
                    CorBase = "Branco com Poá Preto",
                    CategoriaId = 1
                },
                new Produto
                {
                    Id = 6,
                    Nome = "Maiô Cavado Estampado Tropical",
                    PrecoVenda = 109.90m,
                    PrecoCusto = 50.00m,
                    Descricao = "Maiô com corte cavado e estampa tropical vibrante, para um visual moderno.",                   
                    CorBase = "Multicolorido",
                    CategoriaId = 2
                },
                new Produto
                {
                    Id = 7,
                    Nome = "Saída de Praia Curta Crochê",
                    PrecoVenda = 99.90m,
                    PrecoCusto = 45.00m,
                    Descricao = "Saída de praia curta em crochê, leve e estilosa para os dias quentes.",                    
                    CorBase = "Bege",
                    CategoriaId = 3
                },
                new Produto
                {
                    Id = 8,
                    Nome = "Sungão Slip Listrado",
                    PrecoVenda = 49.90m,
                    PrecoCusto = 22.00m,
                    Descricao = "Sungão modelo slip com estampa listrada, confortável e com ótimo caimento.",                   
                    CorBase = "Azul com Listras Brancas",
                    CategoriaId = 1
                },
                new Produto
                {
                    Id = 9,
                    Nome = "Biquíni Cropped Liso Vermelho",
                    PrecoVenda = 94.90m,
                    PrecoCusto = 42.00m,
                    Descricao = "Biquíni modelo cropped em tecido liso vermelho, moderno e estiloso.",                    
                    CorBase = "Vermelho",
                    CategoriaId = 1
                },
                new Produto
                {
                    Id = 10,
                    Nome = "Maiô Plus Size Floral Escuro",
                    PrecoVenda = 119.90m,
                    PrecoCusto = 55.00m,
                    Descricao = "Maiô plus size com estampa floral em tons escuros, elegante e confortável.",               
                    CorBase = "Preto com Flores",
                    CategoriaId = 2
                },
                new Produto
                {
                    Id = 11,
                    Nome = "Saída de Praia Vestido Estampado",
                    PrecoVenda = 114.90m,
                    PrecoCusto = 52.00m,
                    Descricao = "Saída de praia modelo vestido com estampa colorida, prático e charmoso.",                 
                    CorBase = "Estampado",
                    CategoriaId = 3
                },
                new Produto
                {
                    Id = 12,
                    Nome = "Sungão Estampado Abstrato",
                    PrecoVenda = 64.90m,
                    PrecoCusto = 30.00m,
                    Descricao = "Sungão com estampa abstrata moderna, para um visual diferenciado.",                   
                    CorBase = "Multicolorido",
                    CategoriaId = 1
                },
                new Produto
                {
                    Id = 13,
                    Nome = "Biquíni Hot Pant Liso Preto",
                    PrecoVenda = 99.90m,
                    PrecoCusto = 45.00m,
                    Descricao = "Biquíni modelo hot pant em tecido liso preto, elegante e com bom caimento.",                    
                    CorBase = "Preto",
                    CategoriaId = 1
                },
                 new Produto
                 {
                     Id = 14,
                     Nome = "Maiô com Bojo Liso Verde Água",
                     PrecoVenda = 104.90m,
                     PrecoCusto = 48.00m,
                     Descricao = "Maiô com bojo em tecido liso verde água, confortável e com bom suporte.",                     
                     CorBase = "Verde Água",
                     CategoriaId = 2
                 },
                 new Produto
                 {
                     Id = 15,
                     Nome = "Saída de Praia Camisa Listrada",
                     PrecoVenda = 109.90m,
                     PrecoCusto = 50.00m,
                     Descricao = "Saída de praia modelo camisa com estampa listrada, moderna e versátil.",                    
                     CorBase = "Branco com Listras Azuis",
                     CategoriaId = 3
                 });

                    modelBuilder.Entity<Produto>()
                   .Property(p => p.PrecoCusto)
                   .HasPrecision(18, 2);

                    modelBuilder.Entity<Produto>()
                   .Property(p => p.PrecoVenda)
                   .HasPrecision(18, 2);
                }
            }
}