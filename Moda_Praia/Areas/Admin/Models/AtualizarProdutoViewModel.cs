using Moda_Praia.Models;

namespace Moda_Praia.Areas.Admin.Models
{
    public class AtualizarProdutoViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoCusto { get; set; }
        public string? Descricao { get; set; }
        public string? CorBase { get; set; }        
        public int? CategoriaId { get; set; }
        public List<ImagensProdutoViewModel>? ImagensRoupaVIewModel { get; set; } // carregar do banco
        public List<Categoria>? CategoriasDisponiveisParaSelecao { get; set; } // carregar antes de chamar a view
        public List<Tamanho>? TamanhosDisponiveisParaSelecao { get; set; }  //carregar antes de chamar a view
        public List<ProdutoTamanhoViewModel>? TamanhosSelecionados { get; set; } = new List<ProdutoTamanhoViewModel>();  // carregar do banco

    }
}
