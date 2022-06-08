namespace LocadoraAPI.Models
{
    public class Locacao
    {
        public int IdLocacao { get; set; }
        public int IdFilme { get; set; }
        public int IdCliente { get; set; }
        public DateTime DataDevolucao { get; set; }
        public bool Ativo { get; set; }
    }
}
