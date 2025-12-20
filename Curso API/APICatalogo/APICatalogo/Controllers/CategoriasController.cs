using APICatalogo.Context;
using APICatalogo.Domain_Models;
using APICatalogo.Repositories;
using APICatalogo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]             // url: /categoria
    [ApiController]
    public class CategoriasController : Controller
    {
        //private readonly IRepository<Categoria> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public CategoriasController(IUnitOfWork unitOfWork, ILogger<CategoriasController> logger)       // solicito ao framework a instancia, que é injetada pelo container de inativos
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // [HttpGet("produtos")]
        // public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        // {
        //     _logger.LogInformation("========= GET api/categorias/produtos =========");
        //     return _context.Categorias.Include(p=> p.Produtos).Where(c => c.CategoriaId <= 20).ToList();      // o método de extensão Include permite carregar entidades relacionadas
        // }                                                                                                     // retorna a categoria com os produtos inclusos. (verificar chat Explicação sobre Include())

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetCategorias()
        {
            //var categorias = _repository.GetAll();
            var categorias = _unitOfWork.CategoriaRepository.GetAll();
            return Ok(categorias);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            //var categoria = _repository.Get(c => c.CategoriaId == id);
            var categoria = _unitOfWork.CategoriaRepository.Get(c => c.CategoriaId == id);

            if (categoria is null)
            {
                _logger.LogWarning($"Categoria com id={id} não encontrada...");
                return NotFound($"Categoria com id={id} não encontrada...");
            }

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if(categoria is null)
            {
                _logger.LogWarning($"Dados inválidos");
                return BadRequest("Dados inválidos");
            }

            ;// var categoriaCriada = _repository.Create(categoria);
            var categoriaCriada = _unitOfWork.CategoriaRepository.Create(categoria);
            _unitOfWork.Commit();

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoriaCriada.CategoriaId}, categoriaCriada);
        }

        [HttpPut("{id:int}")]                                       // esse id é mapeado para o parametro id do metodo put
        public ActionResult Put(int id, Categoria categoria)        // 'id' vem da URL (rota) (localhost:xyz/categorias/id, e 'produto' é o corpo (body) da requisição
        {
            if (id != categoria.CategoriaId)
            {
                _logger.LogWarning($"Dados inválidos. O novo id modifica o id anterior");
                return BadRequest($"Dados inválidos. O novo id modifica o id anterior");
            }

            //_repository.Update(categoria);
            _unitOfWork.CategoriaRepository.Update(categoria);
            _unitOfWork.Commit();

            return Ok(categoria);                
        }

        [HttpDelete("{id:int:min(1)}")]                         // esse id é mapeado para o parametro id do metodo Delete
        public ActionResult Delete(int id)
        {
            //var categoria = _repository.Get(c => c.CategoriaId == id);
            var categoria = _unitOfWork.CategoriaRepository.Get(c => c.CategoriaId == id);

            if (categoria is null)
            {
                _logger.LogWarning($"Categoria com id={id} não encontrada");
                return BadRequest($"Categoria com id={id} não encontrada");
            }

            //var categoriaExcluida = _repository.Delete(categoria);
            var categoriaExcluida = _unitOfWork.CategoriaRepository.Delete(categoria);
            _unitOfWork.Commit();

            return Ok(categoriaExcluida);
        }
    }
}
