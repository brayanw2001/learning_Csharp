using APICatalogo.Context;
using APICatalogo.Domain_Models;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _repository;

        public ProdutosController(IProdutoRepository repository)     // /produtos
        {
            _repository = repository;
        }

        [HttpGet]        // /produto                                         // action result permite que possa retornar uma lista de produtos(pois, <Produto>) ou todos os metodos de retorno suportados por actionresult (notfound, badrequest, etc)
        public ActionResult<IEnumerable<Produto>> GetProdutosAsync()                     // IEnumerable permite adiar a execução, vai trabalhar sob demanda. Não preciso ter, inicialmente, toda a coleção na memória 
        {
            var produtos = _repository.GetProdutos().ToList();       // através do contexto, acesso produtos
            
            try
            {
                if (produtos is null)
                    return NotFound("Produtos não encontrados...");  
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }

            return Ok(produtos);
        }

        // /produto/primeiro
        [HttpGet("primeiro")]         // / especializando o roteamento | composição de rota                                                
        public ActionResult<Produto> GetPrimeiro()                     
        {
            var produto = _repository.GetProdutos().FirstOrDefault();  
            
            try
            {
                if (produto is null)
                    return NotFound("Produtos não encontrados...");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }

            return Ok(produto);
        }

        // /produtos/id
        [HttpGet("{id:int}", Name="ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            try
            {
                var produto = _repository.GetProdutoId(id);

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

               var novoProduto = _repository.CreateProduto(produto);       

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

                if(_repository.Update(produto) == true)
                    return Ok(produto);

                return StatusCode(500, $"Falha ao atualizar o produto de id = {id}");
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
                Boolean deletado = _repository.Delete(id);
                
                if (deletado)
                    return Ok($"O produto de id = {id} foi deletado");

                return StatusCode(500, $"Falha ao excluir o produto de id = {id}");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }
        }
    }
}
