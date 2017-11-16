using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iMarket.Models
{
    [Table("ItensCompra")]
    public class ItensCompra
    {
        [Key]
        [Column(Order = 1)]
        public int CompraId { get; set; }
        public Compra Compra { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        [Required]
        public byte Quantidade { get; set; }

        [Required]
        public Decimal PrecoProduto { get; set; }
    }
}