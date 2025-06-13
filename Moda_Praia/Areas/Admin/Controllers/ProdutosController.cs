using Microsoft.AspNetCore.Mvc;
using Moda_Praia.Areas.Admin.Models;
using Moda_Praia.Data;
using Moda_Praia.Models;

namespace Moda_Praia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Produto> produtosDb = _context.Produtos.ToList();
            return View(produtosDb);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(produtoViewModel);
            }
            var produtoBranco = new Produto
            {
                Nome = produtoViewModel.Nome,
                PrecoVenda = produtoViewModel.PrecoVenda,
                PrecoCusto = produtoViewModel.PrecoCusto,
                Descricao = produtoViewModel.Descricao,
                Categoria = produtoViewModel.Categoria,
                urlName = produtoViewModel.urlName,
                QuantidadeEstoque = produtoViewModel.QuantidadeEstoque,
                CorBase = produtoViewModel.CorBase

            };
            _context.Add(produtoBranco);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
