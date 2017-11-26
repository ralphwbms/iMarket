using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iMarket.Models
{
    [Table("Supermercados")]
    public class Supermercado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required]
        [MaxLength(80)]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required]
        [MaxLength(14)]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

        [Required]
        [MaxLength(80)]
        [Display(Name = "Endereço")]
        public string Logradouro { get; set; }

        [Required]
        [Display(Name = "Nº")]
        public int Numero { get; set; }

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

        [Required]
        [MaxLength(20)]
        [Display(Name = "Telefone de Contato")]
        public string TelefoneContato { get; set; }

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