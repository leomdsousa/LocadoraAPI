using System.ComponentModel.DataAnnotations;

namespace LocadoraAPI.DTOs
{
    public class LocacaoDTOInput
    {
        public int IdLocacao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o id do filme.")]
        public int IdFilme { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o id do cliente.")]
        public int IdCliente { get; set; }
    }
}
