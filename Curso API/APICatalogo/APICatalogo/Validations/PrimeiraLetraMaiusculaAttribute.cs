
using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Validations
{
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            char primeiraLetra = value.ToString()[0];

            if (primeiraLetra != char.ToUpper(primeiraLetra))
            {
                return new ValidationResult("A primeira letra deve ser maiúscula");
            }

            return ValidationResult.Success;
        }
    }
}
