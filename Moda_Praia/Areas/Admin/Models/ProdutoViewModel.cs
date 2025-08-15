using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Moda_Praia.Models;

namespace Moda_Praia.Areas.Admin.Models
{
    public class ProdutoViewModel
    {
        
        [DisplayName("Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        [DisplayName("Nome do Produto")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O preço de venda é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço de venda deve ser maior que zero.")]
        [DisplayName("Preço de Venda")]
        public decimal PrecoVenda { get; set; }

        [Required(ErrorMessage = "O preço de custo é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço de custo deve ser maior que zero.")]
        [DisplayName("Preço de Custo")]
        public decimal PrecoCusto { get; set; }
        [Required(ErrorMessage = "A descrição do produto é obrigatório.")]
        [StringLength(500, ErrorMessage = "A descrição não pode exceder 500 caracteres.")]
        [DisplayName("Descrição do Produto")]
        public string? Descricao { get; set; }

        
        [DisplayName("Fotos")]
        public IEnumerable< IFormFile> ? ImagensRoupa { get; set; }        

        [Required(ErrorMessage = "A cor principal é obrigatória.")]
        [StringLength(50, ErrorMessage = "A cor principal não pode exceder 50 caracteres.")]
        [DisplayName("Cor")]
        public string? CorBase { get; set; }

        public int CategoriaId { get; set; }
        public List<Categoria>? CategoriasDisponiveis { get; set; }
        public List<Tamanho>? TamanhosDisponiveisParaSelecao { get; set; }
        public List<ProdutoTamanhoViewModel> TamanhosSelecionados { get; set; } = new List<ProdutoTamanhoViewModel>();

    }
}
