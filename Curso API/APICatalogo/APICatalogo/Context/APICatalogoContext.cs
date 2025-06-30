using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context;

public class APICatalogoContext : DbContext
{
    public APICatalogoContext(DbContextOptions<APICatalogoContext> options) : base(options)
    {       
    }


    // criar as tabelas a partir das classes (mapeamento objeto relacional)
    public DbSet<Categoria>? Categorias { get; set; }           // ? -> garante que a propriedade seja opcional
    public DbSet<Produto>? Produtos { get; set; }
}
