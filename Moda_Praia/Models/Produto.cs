using System.ComponentModel;

namespace Moda_Praia.Models
{
    public class Produto
    {
        [DisplayName("Codigo")]
        public int Id { get; set; }
        public string? Nome { get; set; }
        [DisplayName("Preço")]
        public decimal PrecoVenda { get; set; }
        [DisplayName("Preço de Custo")]
        public decimal PrecoCusto { get; set; }
        [DisplayName("Descrição do Produto")]
        public string? Descricao { get; set; }
        [DisplayName("Qtd")]
        public int? QuantidadeEstoque { get; set; }
        [DisplayName("Cor Principal")]
        public string? CorBase { get; set; }
        public int? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public List<ProdutoImagem>? ProdutoImagens { get; set; }
        public List<ProdutoTamanho>? ProdutoTamanhos { get; set; }
    }
}
