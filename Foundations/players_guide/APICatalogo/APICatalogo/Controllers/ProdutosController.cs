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

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]                                            // action result permite que possa retornar uma lista de produtos(pois, <Produto>) ou todos os metodos de retorno suportados por actionresult (notfound, badrequest, etc)
        public ActionResult<IEnumerable<Produto>> Get()      // IEnumerable permite adiar a execução, vai trabalhar sob demanda. Não preciso ter, inicialmente, toda a coleção na memória 
        {                                             
            var produtos = _context.Produtos.ToList();       // através do contexto, acesso produtos

            if (produtos is null)
                return NotFound("Produtos não encontrados...");
            
            return produtos;
        }

        [HttpGet("{id:int}", Name="ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
                return NotFound();

            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest();
            
            _context.Produtos.Add(produto);          // trabalhando na memoria
            _context.SaveChanges();                 // persiste na tabela

            return new CreatedAtRouteResult("ObterProduto", //nome definido para a rota
                new { id = produto.ProdutoId}, produto);    // informo o id que foi incluído e informo o objeto produto que incluí
        }

        [HttpPut("{id:int}")]                                  // esse id é mapeado para o parametro id do metodo put
        public ActionResult Put(int id, Produto produto)       // 'id' vem da URL (rota), e 'produto' é o corpo (body) da requisição
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]                                  // esse id é mapeado para o parametro id do metodo Delete
        public ActionResult Delete(int id)       
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
    }
}
