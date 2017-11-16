using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iMarket.Models
{
    [Table("Compras")]
    public class Compra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Data da Compra")]
        public DateTime DataHoraCompra { get; set; }

        [Required]
        [Display(Name = "Situação")]
        public string Situacao { get; set; }

        [Required]
        [Display(Name = "Valor da Compra")]
        public Decimal ValorCompra { get; set; }

        [Required]
        [Display(Name = "Valor do Frete")]
        public Decimal ValorFrete { get; set; }

        [Required]
        [Display(Name = "Entrega Agendada Para")]
        public DateTime DataHoraAgendamentoEntrega { get; set; }

        [Required]
        [Display(Name = "Entrega Realizada Em")]
        public DateTime DataHoraEntrega { get; set; }

        public Supermercado Supermercado { get; set; }
        public int SupermercadoId { get; set; }

        public Consumidor Consumidor { get; set; }
        public int ConsumidorId { get; set; }

        public IEnumerable<ItensCompra> ItensCompra { get; set; }
    }
}