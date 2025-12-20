using APICatalogo.Context;
using APICatalogo.Domain_Models;
using APICatalogo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;        // injeta o genérico
        private readonly IRepository<Produto> _repository;             // injeta o específico. Eu poderia utilizar apenas esse, uma vez que o específico herda do genérico

        public ProdutosController(IRepository<Produto> repository, IProdutoRepository produtoRepository)     // /produtos
        {
            _repository = repository;
            _produtoRepository = produtoRepository;

        }
        [HttpGet("Produtos/{id}")]
        public ActionResult<IEnumerable<Produto>> GetProdutosPorCategoria(int id)
        {
            var produtos = _produtoRepository.GetProdutosPorCategoria(id);

            if (produtos is null)
                return NotFound();

            return Ok(produtos);
        }


        [HttpGet("{id:int}", Name="ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            try
            {
                var produto = _repository.Get(c => c.ProdutoId == id);

                if (produto is null)
                    return NotFound("Produto não encontrado");

                return Ok(produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            try
            {
                if (produto is null)
                    return BadRequest();

               var novoProduto = _repository.Create(produto);       

                return new CreatedAtRouteResult("ObterProduto", //nome definido para a rota
                    new { id = produto.ProdutoId}, novoProduto);    // informo o id que foi incluído e informo o objeto produto que incluí
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }

        }

        [HttpPut("{id:int:min(1)}")]                           // esse id é mapeado para o parametro id do metodo put
        public ActionResult Put(int id, Produto produto)       // 'id' vem da URL (rota), e 'produto' é o corpo (body) da requisição
        {
            try
            {
                if (id != produto.ProdutoId)
                    return BadRequest();

                var produtoAtualizado = _repository.Update(produto);

                return Ok(produtoAtualizado);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }
        }

        [HttpDelete("{id:int:min(1)}")]                                  // esse id é mapeado para o parametro id do metodo Delete
        public ActionResult Delete(int id)       
        {
            try
            {
                var deletado = _repository.Get(c => c.ProdutoId == id);

                if (deletado is null)
                    return StatusCode(500, $"Não foi encontrado produto com id = {id}");

                _repository.Delete(deletado);
                 return Ok($"O produto de id = {id} foi deletado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }
        }
    }
}
