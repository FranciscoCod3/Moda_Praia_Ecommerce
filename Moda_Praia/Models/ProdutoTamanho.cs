using System.ComponentModel;

namespace Moda_Praia.Models
{
    public class ProdutoTamanho
    {
        public int ProdutoId { get; set; }
        public int TamanhoId { get; set; }
        [DisplayName("Quantidade")]
        public int Estoque { get; set; } = 0;
        public Produto? Produto { get; set; }
        public Tamanho? Tamanho { get; set; }

    }
}
