using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using APICatalogo.Validations;

namespace APICatalogo.Domain_Models;

public class Produto : IValidatableObject
{
    public int ProdutoId { get; set; }

    [PrimeiraLetraMaiuscula]
    [Required(ErrorMessage = "O nome deve ser obrigatório.")]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(80)]
    public string? Descricao { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    public float Estoque { get; set; }

    public DateTime DataCadastro { get; set; }

    public int CategoriaId { get; set; }            // mapeia para a chave estrangeira no banco de dados
    [JsonIgnore]
    
    public Categoria? Categoria { get; set; }        // propriedade de navegação que indica que um *produto* está relacionado com uma *categoria*

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (this.Estoque <= 0)
        {
            yield return new
                ValidationResult("O estoque deve ser maior que zero",
                new[]
                { nameof(this.Estoque) }
                );
        }
    }
}
