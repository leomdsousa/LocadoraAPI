using LocadoraAPI.DTOs;

namespace LocadoraAPI.Services.Interfaces
{
    public interface ILocacaoService
    {
        List<LocacaoDTOOutput> ObterLocacoes();
        LocacaoDTOOutput ObterLocacao(int idLocacao);
        LocacaoDTOOutput LocarFilme(LocacaoDTOInput dto);
        bool DevolverFilme(int idLocacao, out string mensagem);
    }
}
