using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            IEnumerable<Produto> produtosDb = _context.Produtos.Include(x => x.Categoria).ToList();
            return View(produtosDb);
        }

        public IActionResult Create()
        {
            var categorias = _context.Categorias.ToList();
            var viewModel = new ProdutoViewModel
            {
                CategoriasDisponiveis = categorias
            };

            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult>  Create(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid || produtoViewModel.ImagensRoupa == null || !produtoViewModel.ImagensRoupa.Any(x => x.Length >0))
            {
                return View(produtoViewModel);
            }

            var categoriaSelecionada = _context.Categorias.FirstOrDefault(cat => cat.Id == produtoViewModel.CategoriaId).ToString();

            var produtoBranco = new Produto
            {
                Nome = produtoViewModel.Nome,
                PrecoVenda = produtoViewModel.PrecoVenda,
                PrecoCusto = produtoViewModel.PrecoCusto,
                Descricao = produtoViewModel.Descricao,                
                QuantidadeEstoque = produtoViewModel.QuantidadeEstoque,
                CorBase = produtoViewModel.CorBase,
                CategoriaId = int.Parse( produtoViewModel.CategoriaId.ToString()),
                
            };

            // 1. Lista para armazenar os caminhos das imagens
            var imageUrls = new List<string>();

            // 2. Definir o subdiretório para salvar as imagens (opcional, mas recomendado)
            var uploadsFolder = Path.Combine(_webHost.WebRootPath, "images", categoriaSelecionada);

            // Certifique-se de que o diretório exista
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }



            foreach (var file in produtoViewModel.ImagensRoupa)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    var extension = Path.GetExtension(file.FileName);
                    var uniqueFileName = Guid.NewGuid().ToString() + categoriaSelecionada + extension;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    var relativePathForDb = Path.Combine("images", categoriaSelecionada, uniqueFileName).Replace("\\", "/");

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream); // Use CopyToAsync para melhor performance
                    }
                    imageUrls.Add(relativePathForDb);

                }

            }

            produtoBranco.ProdutoImagens = new List<ProdutoImagem>();

            foreach (var url in imageUrls)
            {
                produtoBranco.ProdutoImagens.Add(new ProdutoImagem { UrlImagem = url });
            }                             

            _context.Add(produtoBranco);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detalhes(int? id)
        {
            if(id == null || id <= 0)
            {
                return View();
            }
            var produtobranco = _context.Produtos.
                Include(x => x.ProdutoImagens).
                FirstOrDefault(x => x.Id == id);
            
            return View(produtobranco);
        }

    }
}
    