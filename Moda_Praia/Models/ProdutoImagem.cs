namespace Moda_Praia.Models
{
    public class ProdutoImagem
    {
        public int Id { get; set; }
        public string UrlImagem {get; set;}
        public int ProdutoId {get; set;}
        public Produto Produto {get; set;}

}
}        