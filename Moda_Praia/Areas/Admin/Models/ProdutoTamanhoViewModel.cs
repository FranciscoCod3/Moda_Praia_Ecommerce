using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Moda_Praia.Areas.Admin.Models
{
    public class ProdutoTamanhoViewModel
    {
        
        [Required(ErrorMessage = "O tamanho é obrigatório.")]
        public int TamanhoId { get; set; }       
        public string? TamanhoNome { get; set; }
       
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
        [DisplayName("Estoque")]
        public int? Quantidade { get; set; }
    }
}