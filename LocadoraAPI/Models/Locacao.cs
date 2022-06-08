using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraAPI.Models
{
    [Table("LOCACAO")]
    public class Locacao
    {
        [Key]
        [Column("ID_LOCACAO")]
        public int IdLocacao { get; set; }

        [Column("ID_FILME")]
        public int IdFilme { get; set; }

        [Column("ID_CLIENTE")]
        public int IdCliente { get; set; }

        [Column("DATA_DEVOLUCAO")]
        public DateTime DataDevolucao { get; set; }

        [Column("ATIVO")]
        public bool Ativo { get; set; }

        [ForeignKey("IdFilme")]
        public virtual Filme? Filme { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente? Cliente { get; set; }
    }
}
