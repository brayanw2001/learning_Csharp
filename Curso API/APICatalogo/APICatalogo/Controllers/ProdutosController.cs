using APICatalogo.Context;
using APICatalogo.Domain_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)     // /produtos
        {
            _context = context;
        }

        [HttpGet]        // /produto                                         // action result permite que possa retornar uma lista de produtos(pois, <Produto>) ou todos os metodos de retorno suportados por actionresult (notfound, badrequest, etc)
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutosAsync()                     // IEnumerable permite adiar a execução, vai trabalhar sob demanda. Não preciso ter, inicialmente, toda a coleção na memória 
        {
            try
            {
                var produtos = _context.Produtos.AsNoTracking().ToList();       // através do contexto, acesso produtos

                if (produtos is null)
                    return NotFound("Produtos não encontrados...");
                
                return await _context.Produtos.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }
        }

        // /produto/primeiro
        [HttpGet("primeiro")]         // / especializando o roteamento | composição de rota                                                
        public ActionResult<Produto> GetPrimeiro()                     
        {
            try
            {
                var produto = _context.Produtos.AsNoTracking().FirstOrDefault();       

                if (produto is null)
                    return NotFound("Produtos não encontrados...");

                return produto;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }
        }

        // /produtos/id
        [HttpGet("{id:int}", Name="ObterProduto")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            try
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == id);

                if (produto is null)
                    return NotFound();

                return produto;
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
            
                _context.Produtos.Add(produto);          // trabalhando na memoria
                _context.SaveChanges();                 // persiste na tabela

                return new CreatedAtRouteResult("ObterProduto", //nome definido para a rota
                    new { id = produto.ProdutoId}, produto);    // informo o id que foi incluído e informo o objeto produto que incluí
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }

        }

        [HttpPut("{id:int:min(1)}")]                                  // esse id é mapeado para o parametro id do metodo put
        public ActionResult Put(int id, Produto produto)       // 'id' vem da URL (rota), e 'produto' é o corpo (body) da requisição
        {
            try
            {
                if (id != produto.ProdutoId)
                {
                    return BadRequest();
                }

                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(produto);
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
                var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

                if(produto is null)
                {
                    return NotFound("Produto não localizado");
                }

                _context.Produtos.Remove(produto);
                _context.SaveChanges();

                return Ok(produto);         // (produto) retorna o produto excluído no response body
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }
        }
    }
}
