using LocadoraAPI.Models;

namespace LocadoraAPI.Repositories.Interfaces
{
    public interface ILocacaoRepository
    {
        List<Locacao> ObterLocacoes();
        Locacao ObterLocacao(int idLocacao);
        Locacao LocarFilme(Locacao locacao);
        Locacao DevolverFilme(Locacao locacao);
        bool ValidarDisponibilidadeFilme(int idFilme);
    }
}
