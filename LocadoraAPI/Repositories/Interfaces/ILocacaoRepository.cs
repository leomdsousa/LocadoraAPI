using LocadoraAPI.Models;

namespace LocadoraAPI.Repositories.Interfaces
{
    public interface ILocacaoRepository
    {
        List<Locacao> ObterLocacoes();
        Locacao ObterLocacao(int idLocacao);
        Locacao LocarFilme(Locacao locacao);
        bool DevolverFilme(int idLocacao);
    }
}
