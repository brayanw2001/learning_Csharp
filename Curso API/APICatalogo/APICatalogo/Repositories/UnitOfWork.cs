using APICatalogo.Context;
using APICatalogo.Repositories.Interfaces;

namespace APICatalogo.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IProdutoRepository? _produtoRepository;
    private ICategoriaRepository? _categoriaRepository;
    public AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }


    public IProdutoRepository ProdutoRepository
    {
        get
        {
            return _produtoRepository = _produtoRepository ?? new ProdutoRepository(_context);
        }
    }

    public ICategoriaRepository CategoriaRepository
    {
        get
        {
            return _categoriaRepository = _categoriaRepository ?? new CategoriaRepository(_context);
        }
    }

    public void commit()
    {
        _context.SaveChanges();
    }

    public void dispose()
    {
        _context.Dispose();
    }
}




