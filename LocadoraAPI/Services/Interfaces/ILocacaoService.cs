using LocadoraAPI.DTOs;

namespace LocadoraAPI.Services.Interfaces
{
    public interface ILocacaoService
    {
        List<LocacaoDTO> ObterLocacoes();
        LocacaoDTO ObterLocacao(int idLocacao);
        LocacaoDTO LocarFilme(LocacaoDTO dto);
        bool DevolverFilme(int idLocacao);
    }
}
