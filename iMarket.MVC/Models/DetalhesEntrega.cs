using System.ComponentModel.DataAnnotations;

namespace iMarket.Models
{
    public class DetalhesEntrega
    {
        [Required(ErrorMessage = "Por favor informe seu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor informe seu endereço de entrega preferencial")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Por favor informe sua cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Por favor informe seu estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Por favor informe o CEP")]
        public string CEP { get; set; }

        public bool AgendarEntrega { get; set; }
    }
}