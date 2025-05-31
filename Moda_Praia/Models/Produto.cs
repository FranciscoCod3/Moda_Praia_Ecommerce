using System.ComponentModel;

namespace Moda_Praia.Models
{
    public class Produto
    {
        [DisplayName("Identificador")]
        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayName("Preço")]
        public decimal PrecoVenda { get; set; }
        [DisplayName("Preço de Custo")]
        public decimal PrecoCusto { get; set; }
        [DisplayName("Descrição do Produto")]
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string urlName { get; set; }
        [DisplayName("Quantidade")]
        public int? QuantidadeEstoque { get; set; }
        [DisplayName("Cor Principal")]
        public string CorBase { get; set; }
    }
}
