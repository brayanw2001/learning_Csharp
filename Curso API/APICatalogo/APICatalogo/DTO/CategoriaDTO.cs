using APICatalogo.Validations;
using System.ComponentModel.DataAnnotations;

namespace APICatalogo.DTO
{
    public class CategoriaDTO
    {
        public int CategoriaId { get; set; }    // chave primária

        [Required]
        [StringLength(80)]
        [PrimeiraLetraMaiuscula]
        public string? Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }
    }
}
