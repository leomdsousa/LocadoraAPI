using LocadoraAPI.Context;
using LocadoraAPI.Models;
using LocadoraAPI.Repositories.Interfaces;

namespace LocadoraAPI.Repositories
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private LocadoraDBContext _context;

        public LocacaoRepository(LocadoraDBContext context)
        {
            _context = context;
        }

        public bool DevolverFilme(int idLocacao)
        {
            throw new NotImplementedException();
        }

        public Locacao LocarFilme(Locacao locacao)
        {
            throw new NotImplementedException();
        }

        public Locacao ObterLocacao(int idLocacao)
        {
            throw new NotImplementedException();
        }

        public List<Locacao> ObterLocacoes()
        {
            throw new NotImplementedException();
        }
    }
}
