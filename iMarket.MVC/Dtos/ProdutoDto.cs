using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using iMarket.Models;

namespace iMarket.Dtos
{
    public class ProdutoDto
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
        public bool TemEstoque { get; set; }

        public byte DepartamentoId { get; set; }

        public int SupermercadoId { get; set; }
    }
}