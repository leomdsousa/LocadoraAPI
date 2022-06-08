using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraAPI.Models
{
    [Table("FILME")]
    public class Filme
    {
        [Key]
        [Column("ID_FILME")]
        public int IdFilme { get; set; }

        [Column("NOME_FILME")]
        public string? NomeFilme { get; set; }

        [Column("ATIVO")]
        public bool Ativo { get; set; }
    }
}
