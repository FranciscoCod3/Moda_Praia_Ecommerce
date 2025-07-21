using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _webHost;

        public ProdutosController(AppDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
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
        public async Task<IActionResult>  Create(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid || produtoViewModel.ImagemRoupa == null || produtoViewModel.ImagemRoupa.Length <= 0)
            {
                return View(produtoViewModel);
            }

            // 1. Gerar um nome de arquivo único
            var fileName = Path.GetFileNameWithoutExtension(produtoViewModel.ImagemRoupa.FileName);
            var extension = Path.GetExtension(produtoViewModel.ImagemRoupa.FileName);
            var uniqueFileName = Guid.NewGuid().ToString() + produtoViewModel.Categoria + extension ;

            // 2. Definir o subdiretório para salvar as imagens (opcional, mas recomendado)
            var uploadsFolder = Path.Combine(_webHost.WebRootPath, "images", produtoViewModel.Categoria);

            // Certifique-se de que o diretório exista
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // 3. Montar o caminho completo para salvar o arquivo físico
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // 4. Montar o caminho relativo para salvar no banco de dados
            // Este é o caminho que você usaria em um <img src="..."> no HTML
            var relativePathForDb = Path.Combine("images", produtoViewModel.Categoria, uniqueFileName).Replace("\\", "/");
            


            // Salvar o arquivo fisicamente
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await produtoViewModel.ImagemRoupa.CopyToAsync(fileStream); // Use CopyToAsync para melhor performance
            }


            var produtoBranco = new Produto
            {
                Nome = produtoViewModel.Nome,
                PrecoVenda = produtoViewModel.PrecoVenda,
                PrecoCusto = produtoViewModel.PrecoCusto,
                Descricao = produtoViewModel.Descricao,
                Categoria = produtoViewModel.Categoria,
                QuantidadeEstoque = produtoViewModel.QuantidadeEstoque,
                CorBase = produtoViewModel.CorBase,
                urlName = relativePathForDb


            };
            _context.Add(produtoBranco);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
