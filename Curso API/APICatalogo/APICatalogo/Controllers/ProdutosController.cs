using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly APICatalogoContext _context;

        public ProdutosController(APICatalogoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()   // usando IEnum pois a interface é somente leitura e pq permite adiar a execução (trabalha por demanda), não preciso ter toda a coleção na memória
        {                                                 // usamos ActionResult para retornar algo que seja diferente de IEnumerable (recurso da API)
            var produtos = _context.Produtos.ToList();

            if (produtos is null)
            {
                return NotFound();
            }
            return produtos;
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]   // posso restringir à um tipo, nesse caso, int | Name -> rota nomeada
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado");
            }
            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)      // como vou retornar apenas as mensagens de estado HTTP, não é necessário um tipo entre <>
        {                       // objeto do tipo produto ta vindo no body do request

            if (produto is null)
                return BadRequest();

            _context.Produtos.Add(produto);            // salva o dado na coleção produtos na memória (aka inclui no contexto)
            _context.SaveChanges();                    // persiste os dados na tabela 

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);   // retorna 201 create e os dados do produto na rota ObterProduto/id
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id); // produto cujo produtoid seja igual ao id que estou passando
            //var produto = _context.Produtos.Find(id);
            
            if (produto is null)
            {
                return NotFound("Produto não encontrado...");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
