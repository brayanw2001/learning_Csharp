using APICatalogo.Domain_Models;

namespace APICatalogo.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        IQueryable<Produto> GetProdutos();
        Produto GetProdutoId(int id);
        Produto CreateProduto(Produto produto);
        bool Update(Produto produto);
        bool Delete(int id);
    }
}
