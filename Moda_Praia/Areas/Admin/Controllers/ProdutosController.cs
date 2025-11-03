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
             IEnumerable<Produto> produtosDb = _context.Produtos
            .Include(x => x.Categoria) 
            .Include(x => x.ProdutoTamanhos) 
            .ThenInclude(pt => pt.Tamanho) 
            .ToList();

            return View(produtosDb);
        }

        public IActionResult Create()
        {
            var categorias = _context.Categorias.ToList();
            var tamanhos = _context.Tamanhos.ToList(); 
            var viewModel = new ProdutoViewModel
            {
                CategoriasDisponiveis = categorias,
                TamanhosDisponiveisParaSelecao = tamanhos,
                TamanhosSelecionados = new List<ProdutoTamanhoViewModel>()
            };

            foreach (var tamanho in tamanhos)
            {
                viewModel.TamanhosSelecionados.Add(new ProdutoTamanhoViewModel
                {
                    
                    TamanhoId = tamanho.Id,                   
                    TamanhoNome = tamanho.Name,                    
                    Quantidade = 0,

                    
                });
            }   

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


            // Lista para armazenar os caminhos das imagens
            var imageUrls = new List<string>();

            // Inicia a transação do banco de dados para garantir que a operação seja atômica
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Busca o nome da categoria para a pasta de imagens
                    var categoriaSelecionada = _context.Categorias.FirstOrDefault(cat => cat.Id == produtoViewModel.CategoriaId)?.Nome;

                    // Se a categoria não for encontrada, retorna um erro
                    if (string.IsNullOrEmpty(categoriaSelecionada))
                    {
                        ModelState.AddModelError("CategoriaId", "A categoria selecionada é inválida.");
                        await transaction.RollbackAsync();
                        return View(produtoViewModel);
                    }

                    // 1. Salva as imagens no sistema de arquivos
                    var uploadsFolder = Path.Combine(_webHost.WebRootPath, "images", categoriaSelecionada);
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    foreach (var file in produtoViewModel.ImagensRoupa)
                    {
                        if (file != null && file.Length > 0)
                        {
                            // Gera um nome de arquivo único para evitar conflitos
                            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                            var relativePathForDb = Path.Combine("images", categoriaSelecionada, uniqueFileName).Replace("\\", "/");

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                            imageUrls.Add(relativePathForDb);
                        }
                    }

                    // 2. Cria a entidade Produto e associa as imagens
                    var produtoBanco = new Produto
                    {
                        Nome = produtoViewModel.Nome,
                        PrecoVenda = produtoViewModel.PrecoVenda,
                        PrecoCusto = produtoViewModel.PrecoCusto,
                        Descricao = produtoViewModel.Descricao,
                        CorBase = produtoViewModel.CorBase,
                        CategoriaId = produtoViewModel.CategoriaId,
                    };
                    produtoBanco.ProdutoImagens = new List<ProdutoImagem>();
                    foreach (var url in imageUrls)
                    {
                        produtoBanco.ProdutoImagens.Add(new ProdutoImagem { UrlImagem = url });
                    }

                    // Adiciona o produto ao contexto. Ele será salvo no SaveChanges final.
                    _context.Add(produtoBanco);

                    // 3. Adiciona as entidades ProdutoTamanho ao contexto
                    foreach (var item in produtoViewModel.TamanhosSelecionados)
                    {
                        // Verifica se a quantidade foi preenchida
                        if (item.TamanhoSelecionado)
                        {
                            var tamnhoProdutoBanco = new ProdutoTamanho();

                            // Associa a instância do produto (o EF resolve o Id no SaveChanges)
                            tamnhoProdutoBanco.Produto = produtoBanco;

                            tamnhoProdutoBanco.TamanhoId = item.TamanhoId;
                            tamnhoProdutoBanco.Estoque = item.Quantidade.Value;

                            _context.Add(tamnhoProdutoBanco);
                        }

                        if (!item.TamanhoSelecionado)
                        {
                            var tamnhoProdutoBanco = new ProdutoTamanho();

                            // Associa a instância do produto (o EF resolve o Id no SaveChanges)
                            tamnhoProdutoBanco.Produto = produtoBanco;

                            tamnhoProdutoBanco.TamanhoId = item.TamanhoId;
                            tamnhoProdutoBanco.Estoque = 0;

                            _context.Add(tamnhoProdutoBanco);
                        }


                    }

                    // 4. Salva todas as alterações (Produto, Imagens, Tamanhos) de uma vez
                    // O EF resolve a ordem das inserções e os IDs automaticamente.
                    await _context.SaveChangesAsync();

                    // 5. Se o SaveChanges() foi bem-sucedido, confirma a transação
                    await transaction.CommitAsync();

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    // Em caso de qualquer erro, reverte a transação do banco de dados
                    await transaction.RollbackAsync();

                    // Mensagem de erro para o usuário
                    ModelState.AddModelError("", "Ocorreu um erro ao salvar o produto. Por favor, tente novamente.");

                    // Lógica para apagar as imagens salvas no disco

                    return View(produtoViewModel);
                }
            }
        }


        public IActionResult AtualizarProduto(int? id)
        {
           
            var categoriasDisponiveis = _context.Categorias.Select(c => new Categoria
            {
                Id = c.Id,
                Nome = c.Nome
            }).ToList();

            var tamanhosDisponiveis = _context.Tamanhos.Select(t => new Tamanho
            {
                Id = t.Id,
                Name = t.Name
            }).ToList();

            var produtoAtualizar = _context.Produtos
                 .Where(x => x.Id == id)
                 .Select(p => new AtualizarProdutoViewModel
                 {
                     Id = p.Id,
                     Nome = p.Nome,
                     PrecoCusto = p.PrecoCusto,
                     PrecoVenda = p.PrecoVenda,
                     Descricao = p.Descricao,
                     CorBase = p.CorBase,
                     CategoriaId = p.CategoriaId,

                     ImagensRoupaVIewModel = p.ProdutoImagens.Select(i => new ImagensProdutoViewModel
                     {
                         UrlImagem = i.UrlImagem
                     }).ToList(),

                     TamanhosSelecionados = p.ProdutoTamanhos.Select(t => new ProdutoTamanhoViewModel
                     {
                         TamanhoId = t.TamanhoId,
                         TamanhoNome = t.Tamanho.Name,
                         Quantidade = t.Estoque,
                         TamanhoSelecionado = t.Estoque> 0
                         

                     }).ToList()
                     

                 }).FirstOrDefault();

            produtoAtualizar.CategoriasDisponiveisParaSelecao = categoriasDisponiveis;
            produtoAtualizar.TamanhosDisponiveisParaSelecao = tamanhosDisponiveis;


            return View(produtoAtualizar);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AtualizarProduto(int id, AtualizarProdutoViewModel produto)
        {
            

            return Ok(produto);        
        }




        public IActionResult Detalhes(int? id)
        {
            if(id == null || id <= 0)
            {
                return View();
            }
            var produtobanco = _context.Produtos.
                Include(x => x.ProdutoImagens).
                Include(x => x.ProdutoTamanhos).
                FirstOrDefault(x => x.Id == id);
            
            return View(produtobanco);
        }

    }
}
    