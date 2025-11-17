using APICatalogo.Context;
using APICatalogo.Domain_Models;
using APICatalogo.Repositories.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> GetCategorias()
        {
           return _context.Categorias.ToList();
        }

        public Categoria GetCategoriaId(int id)
        {
            return _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
        }

        public Categoria CreateCategoria(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }

            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public Categoria Update(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }
            else
            {
                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();
                return categoria;
            }
        }

        public Categoria Delete(int id)
        {
           var categoria = _context.Categorias.Find(id);
           
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }
            else
            {
                _context.Remove(categoria);
                _context.SaveChanges();
                return categoria;
            }
        }

    }
}
