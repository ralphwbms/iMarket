using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iMarket.Models
{
    [Table("Consumidores")]
    public class Consumidor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(80)]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Required]
        [MaxLength(11)]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required]
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [Required]
        [Display(Name = "Cadastrado Em")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey("UsuarioId")]
        public User Usuario { get; set; }
        public string UsuarioId { get; set; }
    }
}