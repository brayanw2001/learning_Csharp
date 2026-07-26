using APICatalogo.Domain_Models;
using APICatalogo.DTO;
using APICatalogo.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IProdutoRepository _produtoRepository;        // injeta o genérico
        //private readonly IRepository<Produto> _repository;             // injeta o específico. Eu poderia utilizar apenas esse, uma vez que o específico herda do genérico

        public ProdutosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_repository = repository;
            //_produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("/produtos")]
        public ActionResult<IEnumerable<Produto>> GetProdutos()
        {
            IEnumerable<Produto> produtos = _unitOfWork.ProdutoRepository.GetAll();

            if (produtos is null)
            {
                return NotFound();
            }

            return Ok(produtos);
        }

        [HttpGet("Produtos/{id}")]
        public ActionResult<IEnumerable<Produto>> GetProdutosPorCategoria(int id)
        {
            var produtos = _unitOfWork.ProdutoRepository.GetProdutosPorCategoria(id);

            if (produtos is null)
                return NotFound();

            return Ok(produtos);
        }


        [HttpGet("{id:int}", Name="ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            try
            {
                var produto = _unitOfWork.ProdutoRepository.Get(c => c.ProdutoId == id);

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

                var novoProduto = _unitOfWork.ProdutoRepository.Create(produto);
                _unitOfWork.Commit();

                return new CreatedAtRouteResult("ObterProduto", //nome definido para a rota
                    new { id = produto.ProdutoId}, novoProduto);    // informo o id que foi incluído e informo o objeto produto que incluí
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }

        }

        [HttpPatch("{id}/UpdatePartial")]
        public ActionResult<ProdutoDTOUpdateResponse> Patch(int id,
            JsonPatchDocument<ProdutoDTOUpdateRequest> patchProdutoDTO)
        {
            if (patchProdutoDTO is null || id <= 0)
            {
                return BadRequest();
            }

            Produto? produto = _unitOfWork.ProdutoRepository.Get(c => c.ProdutoId == id);

            if (produto is null)
            {
                return NotFound();
            }

            ProdutoDTOUpdateRequest produtoUpdateRequest = _mapper.Map<ProdutoDTOUpdateRequest>(produto);

            patchProdutoDTO.ApplyTo(produtoUpdateRequest, ModelState);

            if (!ModelState.IsValid || !TryValidateModel(produtoUpdateRequest))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(produtoUpdateRequest, produto);

            _unitOfWork.ProdutoRepository.Update(produto);
            _unitOfWork.Commit();

            return Ok(_mapper.Map<ProdutoDTOUpdateResponse>(produto));
        }

        [HttpPut("{id:int:min(1)}")]                           // esse id é mapeado para o parametro id do metodo put
        public ActionResult Put(int id, Produto produto)       // 'id' vem da URL (rota), e 'produto' é o corpo (body) da requisição
        {
            try
            {
                if (id != produto.ProdutoId)
                    return BadRequest();

                var produtoAtualizado = _unitOfWork.ProdutoRepository.Update(produto);
                _unitOfWork.Commit();

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
                var deletado = _unitOfWork.ProdutoRepository.Get(c => c.ProdutoId == id);

                if (deletado is null)
                    return StatusCode(500, $"Não foi encontrado produto com id = {id}");

                _unitOfWork.ProdutoRepository.Delete(deletado);
                _unitOfWork.Commit();

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
