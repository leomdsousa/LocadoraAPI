using LocadoraAPI.Context;
using LocadoraAPI.Models;
using LocadoraAPI.Repositories.Interfaces;

namespace LocadoraAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private LocadoraDBContext _context;

        public FilmeRepository(LocadoraDBContext context)
        {
            _context = context;
        }

        public Filme CadastrarFilme(Filme filme)
        {
            if (filme is null)
                throw new NullReferenceException("Filme nulo.");

            var entity = _context.Set<Filme>().Add(filme);
            var count = _context.SaveChanges();

            return count > 0 ? entity.Entity : null;
        }

        public Filme ObterFilme(int idFilme)
        {
            return _context.Set<Filme>().FirstOrDefault(x => x.IdFilme == idFilme);
        }

        public List<Filme> ObterFilmes()
        {
            return _context.Set<Filme>().ToList();
        }
    }
}
