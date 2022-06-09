using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraAPI.Models
{
    [Table("CLIENTE")]
    public class Cliente
    {
        [Key]
        [Column("ID_CLIENTE")]
        public int IdCliente { get; set; }

        [Column("NOME_CLIENTE")]
        [Required]
        public string NomeCliente { get; set; }

        [Column("ATIVO")]
        [Required]
        public int Ativo { get; set; }
    }
}
