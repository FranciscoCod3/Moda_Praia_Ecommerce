using Microsoft.AspNetCore.Mvc;
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

        public IActionResult CreatePost(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View(produto);
            }
            _context.Add(produto);
            return RedirectToAction("Index");
        }
        
    }
}
