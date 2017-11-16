using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iMarket.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        [Range(0d, Double.MaxValue)]
        public Decimal Preco { get; set; }

        [Range(0d, Double.MaxValue)]
        public Decimal PrecoPromocional { get; set; }

        [Required]
        [Display(Name = "Disponível")]
        public bool TemEstoque { get; set; }

        public Departamento Departamento { get; set; }
        public byte DepartamentoId { get; set; }

        public Supermercado Supermercado { get; set; }
        public int SupermercadoId { get; set; }
    }
}