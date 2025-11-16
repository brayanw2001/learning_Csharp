using APICatalogo.Domain_Models;

namespace APICatalogo.Repositories
{
    public interface IProdutoRepository
    {
        IQueryable<Produto> GetProdutos();
        Produto GetProdutoId(int id);
        Produto CreateProduto(Produto produto);
        Boolean Update(Produto produto);
        Boolean Delete(int id);
    }
}
