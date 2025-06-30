using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;

[Table("Categorias")]                           // indica que quero mapear essa entidade como uma tabela chamada "categorias"
public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();   // inicializando a coleção de produtos
    }

    [Key]
    public int CategoriaId { get; set; }        // chave primaria
    [Required]                                  // nome deve ser obrigatório (não nulo)
    [StringLength(80)]                          // define o tamanho maximo e minimo para o tipo
    public string? Nome { get; set; }
    [Required]                                  
    [StringLength(300)]
    public string? ImagemURL { get; set; }

    // uma categoria possui varios produtos, portanto:
    public ICollection<Produto>? Produtos { get; set; }
}


