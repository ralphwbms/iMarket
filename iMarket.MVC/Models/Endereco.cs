using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iMarket.Models
{
    [Table("Enderecos")]
    public class Endereco
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(80)]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [Required]
        [MaxLength(80)]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Required]
        [Display(Name = "Nº")]
        public int Numero { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(8)]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Required]
        [MaxLength(2)]
        [Display(Name = "Estado")]
        public string UF { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        public Consumidor Consumidor { get; set; }
        public int ConsumidorId { get; set; }
    }
}