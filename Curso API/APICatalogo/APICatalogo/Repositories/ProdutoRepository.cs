using APICatalogo.Context;
using APICatalogo.Domain_Models;
using APICatalogo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Produto> GetProdutos()
        {
            return _context.Produtos;
        }

        public Produto GetProdutoId(int id)
        {
            Produto? produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            return produto is null ? throw new KeyNotFoundException($"Produto com ID {id} não encontrado.") : produto;
        }
        public Produto CreateProduto(Produto produto)
        {
                        ArgumentNullException.ThrowIfNull(produto); // equivalente a if (produto == null) {throw new ArgumentNullException(nameof(produto));}

            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;

        }
        public Boolean Update(Produto produto)
        {
            ArgumentNullException.ThrowIfNull(produto); // equivalente a if (produto == null) {throw new ArgumentNullException(nameof(produto));}

            if (_context.Produtos.Any(p => p.ProdutoId == produto.ProdutoId))
            {
                _context.Produtos.Update(produto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Boolean Delete(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto is not null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
