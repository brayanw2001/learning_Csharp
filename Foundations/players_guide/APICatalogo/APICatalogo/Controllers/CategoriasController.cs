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
            return _context.Categorias.Include(p=> p.Produtos).Where(c => c.CategoriaId <= 20).ToList();      // o método de extensão Include permite carregar entidades relacionadas
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            try
            {
                return _context.Categorias.AsNoTracking().ToList();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }

        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {

            try
            {
                var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

                if (categoria == null)
                    return NotFound("Categoria não encontrada...");

                return Ok(categoria);
            }
            catch (Exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }

        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {

            try
            {
                if (categoria is null)
                    return BadRequest("Dados inválidoss.");

                _context.Categorias.Add(categoria);                     // trabalhando na memoria
                _context.SaveChanges();                                 // persiste na tabela

                return new CreatedAtRouteResult("ObterProduto",         //nome definido para a rota
                    new { id = categoria.CategoriaId }, categoria);     // informo o id que foi incluído e informo o objeto produto que incluí              
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }
        }

        [HttpPut("{id:int}")]                                       // esse id é mapeado para o parametro id do metodo put
        public ActionResult Put(int id, Categoria categoria)        // 'id' vem da URL (rota), e 'produto' é o corpo (body) da requisição
        {
            try
            {
                if (id != categoria.CategoriaId)
                {
                    return BadRequest("Dados inválidos.");
                }

                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(categoria);                
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }


        }

        [HttpDelete("{id:int}")]                         // esse id é mapeado para o parametro id do metodo Delete
        public ActionResult Delete(int id)
        {
            try
            {
                var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

                if (categoria is null)
                {
                    return NotFound("Categoria não localizada");
                }

                _context.Categorias.Remove(categoria);
                _context.SaveChanges();

                return Ok(categoria);                       // (produto) retorna o produto excluído no response body
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }
        }
    }
}
