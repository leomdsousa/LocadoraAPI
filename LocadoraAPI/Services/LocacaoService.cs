using LocadoraAPI.DTOs;
using LocadoraAPI.Repositories.Interfaces;
using LocadoraAPI.Services.Interfaces;

namespace LocadoraAPI.Services
{
    public class LocacaoService : ILocacaoService
    {
        private ILocacaoRepository _repository;

        public LocacaoService(ILocacaoRepository repository)
        {
            _repository = repository;
        }

        public bool DevolverFilme(int idLocacao)
        {
            throw new NotImplementedException();
        }

        public LocacaoDTO LocarFilme(LocacaoDTO dto)
        {
            throw new NotImplementedException();
        }

        public LocacaoDTO ObterLocacao(int idLocacao)
        {
            throw new NotImplementedException();
        }

        public List<LocacaoDTO> ObterLocacoes()
        {
            throw new NotImplementedException();
        }
    }
}
