using APICatalogo.Context;
using APICatalogo.Domain_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]             // url: /categoria
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)       // solicito ao framework a instancia, que é injetada pelo container de inativos
        {
            _context = context;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return _context.Categorias.Include(p=> p.Produtos).ToList();      // o método de extensão Include permite carregar entidades relacionadas
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.Categorias.ToList();
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Produtos.FirstOrDefault(p => p.CategoriaId == id);

            if (categoria == null)
                return NotFound("Categoria não encontrada...");

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
                return BadRequest();

            _context.Categorias.Add(categoria);          // trabalhando na memoria
            _context.SaveChanges();                 // persiste na tabela

            return new CreatedAtRouteResult("ObterProduto", //nome definido para a rota
                new { id = categoria.CategoriaID }, categoria);    // informo o id que foi incluído e informo o objeto produto que incluí
        }

        [HttpPut("{id:int}")]                                  // esse id é mapeado para o parametro id do metodo put
        public ActionResult Put(int id, Categoria categoria)       // 'id' vem da URL (rota), e 'produto' é o corpo (body) da requisição
        {
            if (id != categoria.CategoriaID)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]                                  // esse id é mapeado para o parametro id do metodo Delete
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaID == id);

            if (categoria is null)
            {
                return NotFound("Categoria não localizada");
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);         // (produto) retorna o produto excluído no response body
        }
    }
}
