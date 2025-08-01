namespace Moda_Praia.Models
{
    public class Tamanho
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProdutoTamanho>? ProdutoTamanhos { get; set; }
    }
}
