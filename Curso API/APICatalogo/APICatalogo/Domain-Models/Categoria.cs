using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Domain_Models;

public class Categoria
{
    public Categoria()                          // quando definimos uma coleção numa classe, é uma
    {                                           // boa prática inicializar a coleção
        Produtos = new Collection<Produto>();   // pois, se uma classe definiu, então ela mesma deve inicializar
    }

    public int CategoriaId { get; set; }    // chave primária
    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }
       
    public ICollection<Produto>? Produtos { get; set; }       // um para muitos | proprieade estrangeira no banco de dados
}                                                             // mapeia a coluna CategoriaID na tabela de produtos
