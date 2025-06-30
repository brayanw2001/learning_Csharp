using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly APICatalogoContext _context;

        public CategoriasController(APICatalogoContext context)
        {
            _context = context;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return _context.Categorias.Include(p => p.Produtos).ToList();
        }


        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()   
        {                                                 
            return _context.Categorias.ToList();
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrada...");
            }

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)      // como vou retornar apenas as mensagens de estado HTTP, não é necessário um tipo entre <>
        {                       // objeto do tipo categoria ta vindo no body do request

            if (categoria is null)
                return BadRequest();

            _context.Categorias.Add(categoria);            // salva o dado na coleção produtos na memória (aka inclui no contexto)
            _context.SaveChanges();                        // persiste os dados na tabela 

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);   // retorna 201 create e os dados do produto na rota ObterProduto/id
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id); // produto cujo produtoid seja igual ao id que estou passando
                                                                                    //var produto = _context.Produtos.Find(id);

            if (produto is null)
            {
                return NotFound("Categoria não encontrada...");
            }

            _context.Categorias.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
