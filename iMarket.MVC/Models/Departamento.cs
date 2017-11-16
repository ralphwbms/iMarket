using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iMarket.Models
{
    [Table("Departamentos")]
    public class Departamento
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Nome { get; set; }

        [MaxLength(80)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}