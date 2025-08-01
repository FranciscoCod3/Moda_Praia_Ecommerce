namespace Moda_Praia.Models
{
    public class ProdutoTamanho
    {
        public int ProdutoId { get; set; }
        public int TamanhoId { get; set; }
        public int Estoque {  get; set; }
        public Produto? Produto { get; set; }
        public Tamanho? Tamanho { get; set; }

    }
}
