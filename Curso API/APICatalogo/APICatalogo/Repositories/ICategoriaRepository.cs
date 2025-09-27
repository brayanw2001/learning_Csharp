using APICatalogo.Domain_Models;

namespace APICatalogo.Repositories
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria>GetCategorias();
        Categoria GetCategoriaId(int id);
        Categoria CreateCategoria(Categoria categoria);
        Categoria Update(Categoria categoria);
        Categoria Delete(int id);
    }
}
