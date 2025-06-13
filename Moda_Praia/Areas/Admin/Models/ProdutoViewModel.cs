using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Moda_Praia.Areas.Admin.Models
{
    public class ProdutoViewModel
    {
        // O Id não é necessário para criação, mas pode ser útil para edição.
        // Se a ViewModel for usada apenas para criação, você pode removê-lo.
        [DisplayName("Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        [DisplayName("Nome do Produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preço de venda é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço de venda deve ser maior que zero.")]
        [DisplayName("Preço de Venda")]
        public decimal PrecoVenda { get; set; }

        [Required(ErrorMessage = "O preço de custo é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço de custo deve ser maior que zero.")]
        [DisplayName("Preço de Custo")]
        public decimal PrecoCusto { get; set; }

        [StringLength(500, ErrorMessage = "A descrição não pode exceder 500 caracteres.")]
        [DisplayName("Descrição do Produto")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        [StringLength(50, ErrorMessage = "A categoria não pode exceder 50 caracteres.")]
        [DisplayName("Categoria")]
        public string Categoria { get; set; }

        // urlName geralmente é gerado a partir do nome, mas pode ser validado se for inserido manualmente.
        // Se for gerado automaticamente, você pode remover os atributos de validação aqui.
        [StringLength(200, ErrorMessage = "A URL não pode exceder 200 caracteres.")]
        [DisplayName("Nome da URL")]
        public string urlName { get; set; }

        [Required(ErrorMessage = "A quantidade em estoque é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade em estoque não pode ser negativa.")]
        [DisplayName("Quantidade em Estoque")]
        public int? QuantidadeEstoque { get; set; }

        [Required(ErrorMessage = "A cor principal é obrigatória.")]
        [StringLength(50, ErrorMessage = "A cor principal não pode exceder 50 caracteres.")]
        [DisplayName("Cor Principal")]
        public string CorBase { get; set; }
    }
}
