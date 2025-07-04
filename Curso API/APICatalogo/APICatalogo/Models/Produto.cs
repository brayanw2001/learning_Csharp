﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;

[Table("Produtos")]
public class Produto
{
    [Key]
    public int ProdutoId { get; set; }        //chave primaria
    [Required]                                 
    [StringLength(80)]
    public string? Nome { get; set; }
    [Required]
    [StringLength(300)]
    public string? Descricao { get; set; }
    [Required]
    [Column(TypeName = "decimal(10,2)")]    // precisão de 10 dígitos com 2 casas decimais
    public decimal Preco { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }  
    
    public int CategoriaId { get; set; }        // garante uma id para a coluna de categoria na tabela produtos
    public Categoria? categoria { get; set; }
}
