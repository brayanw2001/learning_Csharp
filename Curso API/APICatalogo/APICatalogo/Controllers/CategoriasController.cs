using APICatalogo.Domain_Models;
using APICatalogo.DTO;
using APICatalogo.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]             // url: /categoria
    [ApiController]
    public class CategoriasController : Controller
    {
        //private readonly IRepository<Categoria> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CategoriasController(IUnitOfWork unitOfWork, ILogger<CategoriasController> logger, IMapper mapper)       // solicito ao framework a instancia, que é injetada pelo container de inativos
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        // [HttpGet("produtos")]
        // public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        // {
        //     _logger.LogInformation("========= GET api/categorias/produtos =========");
        //     return _context.Categorias.Include(p=> p.Produtos).Where(c => c.CategoriaId <= 20).ToList();      // o método de extensão Include permite carregar entidades relacionadas
        // }                                                                                                     // retorna a categoria com os produtos inclusos. (verificar chat Explicação sobre Include())

        [HttpGet]
        public ActionResult<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            //var categorias = _repository.GetAll();
            var categorias = _unitOfWork.CategoriaRepository.GetAll();
            var categoriasDto = _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
            return Ok(categoriasDto);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterCategoria")]
        public ActionResult<CategoriaDTO> Get(int id)
        {
            //var categoria = _repository.Get(c => c.CategoriaId == id);
            var categoria = _unitOfWork.CategoriaRepository.Get(c => c.CategoriaId == id);

            if (categoria is null)
            {
                _logger.LogWarning($"Categoria com id={id} não encontrada...");
                return NotFound($"Categoria com id={id} não encontrada...");
            }

            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);

            return Ok(categoriaDto);
        }

        [HttpPost]
        public ActionResult<CategoriaDTO> Post(CategoriaDTO categoriaDto)
        {

            if(categoriaDto is null)
            {
                _logger.LogWarning($"Dados inválidos");
                return BadRequest("Dados inválidos");
            };

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            // var categoriaCriada = _repository.Create(categoria);
            var novaCategoria = _unitOfWork.CategoriaRepository.Create(categoria);
            _unitOfWork.Commit();

            var novaCategoriaDto = _mapper.Map<CategoriaDTO>(novaCategoria);

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = novaCategoriaDto.CategoriaId}, novaCategoriaDto);
        }

        [HttpPut("{id:int}")]                                       // esse id é mapeado para o parametro id do metodo put
        public ActionResult<CategoriaDTO> Put(int id, CategoriaDTO categoriaDto)        // 'id' vem da URL (rota) (localhost:xyz/categorias/id, e 'produto' é o corpo (body) da requisição
        {
            if (id != categoriaDto.CategoriaId)
            {
                _logger.LogWarning($"Dados inválidos. O novo id modifica o id anterior");
                return BadRequest($"Dados inválidos. O novo id modifica o id anterior");
            }

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            //_repository.Update(categoria);
            var categoriaAtualizada = _unitOfWork.CategoriaRepository.Update(categoria);
            _unitOfWork.Commit();

            var categoriaAtualizazdaDto = _mapper.Map<CategoriaDTO>(categoriaAtualizada);

            return Ok(categoriaAtualizazdaDto);                
        }

        [HttpDelete("{id:int:min(1)}")]                         // esse id é mapeado para o parametro id do metodo Delete
        public ActionResult<CategoriaDTO> Delete(int id)
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

            var categoriaExcluidaDto = _mapper.Map<CategoriaDTO>(categoriaExcluida);

            return Ok(categoriaExcluida);
        }
    }
}
