namespace Moda_Praia.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoCusto { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string urlName { get; set; }
        public int? QuantidadeEstoque { get; set; }
        public string CorBase { get; set; }
    }
}
