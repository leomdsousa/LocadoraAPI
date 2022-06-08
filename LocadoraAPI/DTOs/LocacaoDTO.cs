using System.ComponentModel.DataAnnotations;

namespace LocadoraAPI.DTOs
{
    public class LocacaoDTO
    {
        public int IdLocacao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o id do filme.")]
        public int IdFilme { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o id do cliente.")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data de devolução da locação.")]
        public DateTime DataDevolucao { get; set; }
        public bool Ativo { get; set; }
    }
}
