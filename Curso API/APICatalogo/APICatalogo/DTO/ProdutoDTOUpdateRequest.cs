using System.ComponentModel.DataAnnotations;

namespace APICatalogo.DTO;

public class ProdutoDTOUpdateRequest : IValidatableObject
{
    [Range(1, 9999, ErrorMessage = "Estoque deve ser entre 0 e 9999")]
    public float Estoque { get; set; }

    public DateTime DataCadastro { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (DataCadastro <= DateTime.Now)
        {
            yield return new ValidationResult("A data não pode ser retroativa",
                new[] {nameof(DataCadastro)});
        }
    }
}