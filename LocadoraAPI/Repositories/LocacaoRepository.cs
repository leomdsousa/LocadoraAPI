using LocadoraAPI.Context;
using LocadoraAPI.Models;
using LocadoraAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAPI.Repositories
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private LocadoraDBContext _context;

        public LocacaoRepository(LocadoraDBContext context)
        {
            _context = context;
        }

        public Locacao DevolverFilme(Locacao locacao)
        {
            if (locacao is null)
                throw new NullReferenceException("Locação nula.");

            locacao.DataDevolucao = DateTime.Now;
            locacao.Ativo = 0;

            var entity = _context.Set<Locacao>().Update(locacao);
            var count = _context.SaveChanges();

            return count > 0 ? entity.Entity : null;
        }

        public Locacao LocarFilme(Locacao locacao)
        {
            if (locacao is null)
                throw new NullReferenceException("Locação nula.");

            var entity = _context.Set<Locacao>().Add(locacao);
            var count = _context.SaveChanges();

            return count > 0 ? ObterLocacao(entity.Entity.IdLocacao) : null;
        }

        public Locacao ObterLocacao(int idLocacao)
        {
            return _context.Set<Locacao>().Include(x => x.Cliente).Include(x => x.Filme).FirstOrDefault(x => x.IdLocacao == idLocacao);
        }

        public List<Locacao> ObterLocacoes()
        {
            return _context.Set<Locacao>().Include(x => x.Cliente).Include(x => x.Filme).ToList();
        }

        public bool ValidarDisponibilidadeFilme(int idFilme)
        {
            var filmeAlugado = _context.Set<Locacao>().Any(x => x.IdFilme == idFilme && x.Ativo == 1);

            return filmeAlugado ? false : true;
        }
    }
}
